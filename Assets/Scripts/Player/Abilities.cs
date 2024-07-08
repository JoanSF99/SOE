using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine;
using CI.QuickSave;
using TMPro;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    public Ability[] abilities;
    public Ability[] abilitiesInstances;

    public GameObject firePoint;

    public int slot1;
    public int slot2;
    public bool A_Basic;

    Player player;

    public TextMeshProUGUI manaText;
    public Image bar;

    private void Start()
    {
        player = GetComponent<Player>();

        QuickSaveReader.Create("Player")
            .Read<int>("slot1", (r) => { slot1 = r; })
            .Read<int>("slot2", (r) => { slot2 = r; })
            .Read<bool>("A_Basic", (r) => { A_Basic = r; });
    }

    void Update()
    {
        // Activate ability
        if (Input.GetButtonDown("Fire1"))
        {
            if (A_Basic) 
            {
                abilities[0].Activate(firePoint);
            }
        }

        // Switch to next ability
        if (Input.GetKeyDown(KeyCode.E)) // right button
        {
            if ( slot2 != -1 && player.mana >= abilities[slot2].manaCost)
            {
                player.mana -= abilities[slot2].manaCost;

                abilities[slot2].Activate(firePoint);
            }  
        }

        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (slot1 != -1 && player.mana >= abilities[slot1].manaCost)
            {
                player.mana -= abilities[slot1].manaCost;

                abilities[slot1].Activate(firePoint);
            }
        }

        manaText.text = player.mana.ToString() + "/" + player.maxMana.ToString();
        bar.fillAmount = (float)player.mana/player.maxMana;
    }
}

