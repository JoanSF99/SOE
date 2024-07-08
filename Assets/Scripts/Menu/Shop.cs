using CI.QuickSave;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Player player;

    public DisplayPlayerData playerData;
    public AbilitiesMenu abilitiesMenu;

    public float totalCoins;
    public int health;
    public int mana;

    public bool A_Basic;
    public float A_Basic_cost;
    public GameObject A_Basic_Sold;

    public bool A_Double;
    public float A_Double_cost;
    public GameObject A_Double_Sold;

    public bool A_Invicibility;
    public float A_Invicibility_cost;
    public GameObject A_Invicibility_Sold;

    public bool A_Multi;
    public float A_Multi_cost;
    public GameObject A_Multi_Sold;

    public bool A_Slow;
    public float A_Slow_cost;
    public GameObject A_Slow_Sold;

    public bool H_1;
    public float H_1_cost;
    public GameObject H_1_Sold;

    public bool H_2;
    public float H_2_cost;
    public GameObject H_2_Sold;

    public bool H_3;
    public float H_3_cost;
    public GameObject H_3_Sold;

    public bool H_4;
    public float H_4_cost;
    public GameObject H_4_Sold;

    public bool H_5;
    public float H_5_cost;
    public GameObject H_5_Sold;

    public bool H_6;
    public float H_6_cost;
    public GameObject H_6_Sold;

    public bool M_1;
    public float M_1_cost;
    public GameObject M_1_Sold;

    public bool M_2;
    public float M_2_cost;
    public GameObject M_2_Sold;

    public bool M_3;
    public float M_3_cost;
    public GameObject M_3_Sold;

    public bool M_4;
    public float M_4_cost;
    public GameObject M_4_Sold;

    public bool M_5;
    public float M_5_cost;
    public GameObject M_5_Sold;

    public bool M_6;
    public float M_6_cost;
    public GameObject M_6_Sold;



    private void Start()
    {
        if (QuickSaveReader.RootExists("Player"))
        {
            QuickSaveReader.Create("Player")
                       .Read<bool>("A_Basic", (r) => { A_Basic = r; })
                       .Read<bool>("A_Double", (r) => { A_Double = r; })
                       .Read<bool>("A_Invicibility", (r) => { A_Invicibility = r; })
                       .Read<bool>("A_Multi", (r) => { A_Multi = r; })
                       .Read<bool>("A_Slow", (r) => { A_Slow = r; })
                       .Read<float>("totalPoints", (r) => { totalCoins = r; })
                       .Read<int>("health", (r) => { health = r; })
                       .Read<int>("maxMana", (r) => { mana = r; })
                       .Read<bool>("H_1", (r) => { H_1 = r; })
                       .Read<bool>("H_2", (r) => { H_2 = r; })
                       .Read<bool>("H_3", (r) => { H_3 = r; })
                       .Read<bool>("H_4", (r) => { H_4 = r; })
                       .Read<bool>("H_5", (r) => { H_5 = r; })
                       .Read<bool>("H_6", (r) => { H_6 = r; })
                       .Read<bool>("M_1", (r) => { M_1 = r; })
                       .Read<bool>("M_2", (r) => { M_2 = r; })
                       .Read<bool>("M_3", (r) => { M_3 = r; })
                       .Read<bool>("M_4", (r) => { M_4 = r; })
                       .Read<bool>("M_5", (r) => { M_5 = r; })
                       .Read<bool>("M_6", (r) => { M_6 = r; });
        }
        else
        {
            player.SavePlayer();
        }
        print(mana);
        if (A_Basic)
        {
            A_Basic_Sold.SetActive(true);
        }
        if (A_Double)
        {
            A_Double_Sold.SetActive(true);
        }
        if (A_Invicibility)
        {
            A_Invicibility_Sold.SetActive(true);
        }
        if (A_Multi)
        {
            A_Multi_Sold.SetActive(true);
        }
        if (A_Slow)
        {
            A_Slow_Sold.SetActive(true);
        }
        if (H_1)
        {
            H_1_Sold.SetActive(true);
        }
        if (H_2)
        {
            H_2_Sold.SetActive(true);
        }
        if(H_3)
        {
            H_3_Sold.SetActive(true);
        }
        if(H_4)
        {
            H_4_Sold.SetActive(true);
        }
        if (H_5)
        {
            H_5_Sold.SetActive(true);
        }
        if (H_6)
        {
            H_6_Sold.SetActive(true);
        }
        if (M_1)
        {
            M_1_Sold.SetActive(true);
        }
        if (M_2)
        {
            M_2_Sold.SetActive(true);
        }
        if (M_3)
        {
            M_3_Sold.SetActive(true);
        }
        if (M_4)
        {
            M_4_Sold.SetActive(true);
        }
        if (M_5)
        {
            M_5_Sold.SetActive(true);
        }
        if (M_6)
        {
            M_6_Sold.SetActive(true);
        }
    }

    public void BuyBasic()
    {
        if (!A_Basic)
        {
            if (A_Basic_cost <= totalCoins)
            {
                A_Basic = true;
                totalCoins -= A_Basic_cost;

                QuickSaveWriter.Create("Player")
                      .Write("A_Basic", A_Basic)
                      .Write("totalPoints", totalCoins)
                      .Commit();

                playerData.DisplayData();
                A_Basic_Sold.SetActive(true);
                abilitiesMenu.Set();
            }
        }
    }

    public void BuyDouble()
    {
        if (!A_Double)
        {
            if (A_Double_cost <= totalCoins)
            {
                A_Double = true;
                totalCoins -= A_Double_cost;

                QuickSaveWriter.Create("Player")
                      .Write("A_Double", A_Double)
                      .Write("totalPoints", totalCoins)
                      .Commit();

                playerData.DisplayData();
                A_Double_Sold.SetActive(true);
                abilitiesMenu.Set();
            }
        }
    }

    public void BuyInvicibility()
    {
        if (!A_Invicibility)
        {
            if (A_Invicibility_cost <= totalCoins)
            {
                A_Invicibility = true;
                totalCoins -= A_Invicibility_cost;

                QuickSaveWriter.Create("Player")
                      .Write("A_Invicibility", A_Invicibility)
                      .Write("totalPoints", totalCoins)
                      .Commit();

                playerData.DisplayData();
                A_Invicibility_Sold.SetActive(true);
                abilitiesMenu.Set();
            }
        }
    }

    public void BuyMulti()
    {
        if (!A_Multi)
        {
            if (A_Multi_cost <= totalCoins)
            {
                A_Multi = true;
                totalCoins -= A_Multi_cost;
                QuickSaveWriter.Create("Player")
                    .Write("A_Multi", A_Multi)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                A_Multi_Sold.SetActive(true);
                abilitiesMenu.Set();
            }
        }
    }

    public void BuySlow()
    {
        if (!A_Slow)
        {
            if (A_Slow_cost <= totalCoins)
            {
                A_Slow = true;
                totalCoins -= A_Slow_cost;
                QuickSaveWriter.Create("Player")
                    .Write("A_Slow", A_Slow)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                A_Slow_Sold.SetActive(true);
                abilitiesMenu.Set();
            }
        }
    }

    public void BuyH1()
    {
        if (!H_1)
        {
            if(H_1_cost <= totalCoins)
            {
                H_1 = true;
                health += 1;
                totalCoins -= H_1_cost;

                QuickSaveWriter.Create("Player")
                    .Write("H_1", H_1)
                    .Write("health", health)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                H_1_Sold.SetActive(true);
            }
        }
    }

    public void BuyH2()
    {
        if (!H_2)
        {
            if (H_2_cost <= totalCoins)
            {
                H_2 = true;
                health += 1;
                totalCoins -= H_2_cost;

                QuickSaveWriter.Create("Player")
                    .Write("H_2", H_2)
                    .Write("health", health)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                H_2_Sold.SetActive(true);
            }
        }
    }

    public void BuyH3()
    {
        if (!H_3)
        {
            if (H_3_cost <= totalCoins)
            {
                H_3 = true;
                health += 1;
                totalCoins -= H_3_cost;

                QuickSaveWriter.Create("Player")
                    .Write("H_3", H_3)
                    .Write("health", health)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                H_3_Sold.SetActive(true);
            }
        }
    }

    public void BuyH4()
    {
        if (!H_4)
        {
            if (H_4_cost <= totalCoins)
            {
                H_4 = true;
                health += 1;
                totalCoins -= H_4_cost;

                QuickSaveWriter.Create("Player")
                    .Write("H_4", H_4)
                    .Write("health", health)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                H_4_Sold.SetActive(true);
            }
        }
    }

    public void BuyH5()
    {
        if (!H_5)
        {
            if (H_5_cost <= totalCoins)
            {
                H_5 = true;
                health += 1;
                totalCoins -= H_5_cost;

                QuickSaveWriter.Create("Player")
                    .Write("H_5", H_5)
                    .Write("health", health)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                H_5_Sold.SetActive(true);
            }
        }
    }

    public void BuyH6()
    {
        if (!H_6)
        {
            if (H_6_cost <= totalCoins)
            {
                H_6 = true;
                health += 1;
                totalCoins -= H_6_cost;

                QuickSaveWriter.Create("Player")
                    .Write("H_6", H_6)
                    .Write("health", health)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                H_6_Sold.SetActive(true);
            }
        }
    }

    public void BuyM1()
    {
        if (!M_1)
        {
            if (M_1_cost <= totalCoins)
            {
                M_1 = true;
                mana += 25;
                totalCoins -= M_1_cost;

                QuickSaveWriter.Create("Player")
                    .Write("M_1", M_1)
                    .Write("maxMana", mana)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                M_1_Sold.SetActive(true);
            }
        }
    }

    public void BuyM2()
    {
        if (!M_2)
        {
            if (M_2_cost <= totalCoins)
            {
                M_2 = true;
                mana += 25;
                totalCoins -= M_2_cost;

                QuickSaveWriter.Create("Player")
                    .Write("M_2", M_2)
                    .Write("maxMana", mana)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                M_2_Sold.SetActive(true);
            }
        }
    }

    public void BuyM3()
    {
        if (!M_3)
        {
            if (M_3_cost <= totalCoins)
            {
                M_3 = true;
                mana += 25;
                totalCoins -= M_3_cost;

                QuickSaveWriter.Create("Player")
                    .Write("M_3", M_3)
                    .Write("maxMana", mana)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                M_3_Sold.SetActive(true);
            }
        }
    }

    public void BuyM4()
    {
        if (!M_4)
        {
            if (M_4_cost <= totalCoins)
            {
                M_4 = true;
                mana += 25;
                totalCoins -= M_4_cost;

                QuickSaveWriter.Create("Player")
                    .Write("M_4", M_4)
                    .Write("maxMana", mana)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                M_4_Sold.SetActive(true);
            }
        }
    }

    public void BuyM5()
    {
        if (!M_5)
        {
            if (M_5_cost <= totalCoins)
            {
                M_5 = true;
                mana += 25;
                totalCoins -= M_5_cost;

                QuickSaveWriter.Create("Player")
                    .Write("M_5", M_5)
                    .Write("maxMana", mana)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                M_5_Sold.SetActive(true);
            }
        }
    }

    public void BuyM6()
    {
        if (!M_6)
        {
            if (M_6_cost <= totalCoins)
            {
                M_6 = true;
                mana += 25;
                totalCoins -= M_6_cost;

                QuickSaveWriter.Create("Player")
                    .Write("M_6", M_6)
                    .Write("maxMana", mana)
                    .Write("totalPoints", totalCoins)
                    .Commit();

                playerData.DisplayData();
                M_6_Sold.SetActive(true);
            }
        }
    }
}
