using CI.QuickSave;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPlayerData : MonoBehaviour
{
    //public LoadPlayerData loadPlayerData;
    public TextMeshProUGUI coinsText;
    float _totalCoins;
    public TextMeshProUGUI healthText;
    int _health;
    public TextMeshProUGUI manaText;
    int _mana;

    public Player player;

    private void Start()
    {
        DisplayData();
    }

    public void DisplayData()
    {
        if (QuickSaveReader.RootExists("Player"))
        {
            QuickSaveReader.Create("Player")
                       .Read<int>("health", (r) => { _health = r; })
                       .Read<int>("maxMana", (r) => { _mana = r; })
                       .Read<float>("totalPoints", (r) => { _totalCoins = r; });
        }
        else
        {
            player.SavePlayer();
        }

        manaText.text = _mana.ToString();
        coinsText.text = _totalCoins.ToString();
        healthText.text = _health.ToString();
    }
}
