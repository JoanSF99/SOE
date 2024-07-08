using CI.QuickSave;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public float points = 0;
    public int health = 1;
    public int mana = 100;
    public int maxMana = 100;
    public float manaRegenTime = 0;
    public float distance = 0;
    public float recordDistance = 0;
    public float totalPoints = 0;

    
    public bool A_Basic = false;
    public bool A_Double = false;
    public bool A_Invicibility = false;
    public bool A_Multi = false;
    public bool A_Slow = false;

    public bool H_1 = false;
    public bool H_2 = false;
    public bool H_3 = false;
    public bool H_4 = false;
    public bool H_5 = false;
    public bool H_6 = false;

    public bool M_1 = false;
    public bool M_2 = false;
    public bool M_3 = false;
    public bool M_4 = false;
    public bool M_5 = false;
    public bool M_6 = false;

    public int slot1 = -1;
    public int slot2 = -1;


    private void Start()
    {
        Time.timeScale = 1;

        LoadPlayer();

        mana = maxMana;
    }

    void Update()
    {
        // Regenerate mana
        if (mana < maxMana)
        {
            manaRegenTime += Time.deltaTime;

            if (manaRegenTime >= 1f)
            {
                mana++;
                manaRegenTime--;
            }

            if (mana > maxMana)
            {
                mana = maxMana;
            }
        }
    }

    public void SavePlayer()
    {
        QuickSaveWriter.Create("Player")
                       .Write("health", health)
                       .Write("mana", mana)
                       .Write("maxMana", maxMana)
                       .Write("recordDistance", recordDistance)
                       .Write("totalPoints", totalPoints)
                       .Write("A_Basic", A_Basic)
                       .Write("A_Double", A_Double)
                       .Write("A_Invicibility", A_Invicibility)
                       .Write("A_Multi", A_Multi)
                       .Write("A_Slow", A_Slow)
                       .Write("slot1", slot1)
                       .Write("slot2", slot2)
                       .Write("H_1", H_1)
                       .Write("H_2", H_2)
                       .Write("H_3", H_3)
                       .Write("H_4", H_4)
                       .Write("H_5", H_5)
                       .Write("H_6", H_6)
                       .Write("M_1", M_1)
                       .Write("M_2", M_2)
                       .Write("M_3", M_3)
                       .Write("M_4", M_4)
                       .Write("M_5", M_5)
                       .Write("M_6", M_6)
                       .Commit();
    }

    public void LoadPlayer()
    {
        if (QuickSaveReader.RootExists("Player"))
        {
            QuickSaveReader.Create("Player")
                       .Read<int>("health", (r) => { health = r; })
                       .Read<int>("mana", (r) => { mana = r; })
                       .Read<int>("maxMana", (r) => { maxMana = r; } )
                       .Read<float>("recordDistance", (r) => { recordDistance = r; })
                       .Read<float>("totalPoints", (r) => { totalPoints = r; })
                       .Read<bool>("A_Basic", (r) => { A_Basic = r; })
                       .Read<bool>("A_Double", (r) => { A_Double = r; })
                       .Read<bool>("A_Invicibility", (r) => { A_Invicibility = r; })
                       .Read<bool>("A_Multi", (r) => { A_Multi = r; })
                       .Read<bool>("A_Slow", (r) => { A_Slow = r; })
                       .Read<int>("slot1", (r) => { slot1 = r; })
                       .Read<int>("slot2", (r) => { slot2 = r; })
                       .Read<bool>("M_1", (r) => { M_1 = r; })
                       .Read<bool>("M_2", (r) => { M_2 = r; })
                       .Read<bool>("M_3", (r) => { M_3 = r; })
                       .Read<bool>("M_4", (r) => { M_4 = r; })
                       .Read<bool>("M_5", (r) => { M_5 = r; })
                       .Read<bool>("M_6", (r) => { M_6 = r; })
                       .Read<bool>("H_1", (r) => { H_1 = r; })
                       .Read<bool>("H_2", (r) => { H_2 = r; })
                       .Read<bool>("H_3", (r) => { H_3 = r; })
                       .Read<bool>("H_4", (r) => { H_4 = r; })
                       .Read<bool>("H_5", (r) => { H_5 = r; })
                       .Read<bool>("H_6", (r) => { H_6 = r; });
        }
        else
        {
            SavePlayer();
        }
    }
}
