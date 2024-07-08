using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    public GameObject shopM;
    public GameObject abilitiesM;
    public GameObject optionsM;

    public GameObject player;
    public GameObject abilities;
    public GameObject health;
    public GameObject mana;

    public TMP_Text abilitiesT;
    public TMP_Text healthT;
    public TMP_Text manaT;

    // Shop
    public void SetShopTrue()
    {
        shopM.SetActive(true);
        player.SetActive(false);
        abilities.SetActive(true);
        health.SetActive(false);
        mana.SetActive(false);

        abilitiesT.color = Color.white;
        healthT.color = new Color32(70, 130, 180, 255); ;
        manaT.color = new Color32(70, 130, 180, 255); ;
    }

    public void SetShopFalse()
    {
        shopM.SetActive(false);
        player.SetActive(true);
    }

    public void SetAbiilities()
    {
        abilities.SetActive(true);
        health.SetActive(false);
        mana.SetActive(false);

        abilitiesT.color = Color.white;
        healthT.color = new Color32(70, 130, 180, 255); ;
        manaT.color = new Color32(70, 130, 180, 255); ;
    }

    public void SetHealth()
    {
        abilities.SetActive(false);
        health.SetActive(true);
        mana.SetActive(false);

        abilitiesT.color = new Color32(70, 130, 180, 255); ;
        healthT.color = Color.white;
        manaT.color = new Color32(70, 130, 180, 255); ;
    }

    public void SetMana()
    {
        abilities.SetActive(false);
        health.SetActive(false);
        mana.SetActive(true);

        abilitiesT.color = new Color32(70, 130, 180, 255); ;
        healthT.color = new Color32(70, 130, 180, 255); ;
        manaT.color = Color.white;
    }

    // Abilities
    public void SetAbilitiesTrue()
    {
        abilitiesM.SetActive(true);
        player.SetActive(false);
    }

    public void SetAbilitiesFalse()
    {
        abilitiesM.SetActive(false);
        player.SetActive(true);
    }

    //Options
    // Abilities
    public void SetOptionsTrue()
    {
        optionsM.SetActive(true);
        player.SetActive(false);
    }

    public void SetOptionsFalse()
    {
        optionsM.SetActive(false);
        player.SetActive(true);
    }

}
