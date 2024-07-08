using CI.QuickSave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesMenu : MonoBehaviour
{
    public Player player;

    public int slot1;
    public int slot2;

    public bool A_Double;
    public GameObject A_Double_B;
    public GameObject A_Double_E1;
    public GameObject A_Double_E2;

    public bool A_Invicibility;
    public GameObject A_Invicibility_B;
    public GameObject A_Invicibility_E1;
    public GameObject A_Invicibility_E2;

    public bool A_Multi;
    public GameObject A_Multi_B;
    public GameObject A_Multi_E1;
    public GameObject A_Multi_E2;

    public bool A_Slow;
    public GameObject A_Slow_B;
    public GameObject A_Slow_E1;
    public GameObject A_Slow_E2;


    private void Start()
    {
        Set();
    }

    public void Set()
    {
        if (QuickSaveReader.RootExists("Player"))
        {
            QuickSaveReader.Create("Player")
                       .Read<bool>("A_Double", (r) => { A_Double = r; })
                       .Read<bool>("A_Invicibility", (r) => { A_Invicibility = r; })
                       .Read<bool>("A_Multi", (r) => { A_Multi = r; })
                       .Read<bool>("A_Slow", (r) => { A_Slow = r; })
                       .Read<int>("slot1", (r) => { slot1 = r; })
                       .Read<int>("slot2", (r) => { slot2 = r; });
        }
        else
        {
            player.SavePlayer();
        }
        if (A_Double)
        {
            A_Double_B.SetActive(true);
        }
        if (A_Invicibility)
        {
            A_Invicibility_B.SetActive(true);
        }
        if (A_Multi)
        {
            A_Multi_B.SetActive(true);
        }
        if (A_Slow)
        {
            A_Slow_B.SetActive(true);
        }

        if (slot1 == 1)
        {
            A_Double_E1.SetActive(true);
        }
        else if (slot1 == 2)
        {
            A_Slow_E1.SetActive(true);
        }
        else if (slot1 == 3)
        {
            A_Multi_E1.SetActive(true);
        }
        else if (slot1 == 4)
        {
            A_Invicibility_E1.SetActive(true);
        }

        if (slot2 == 1)
        {
            A_Double_E2.SetActive(true);
        }
        else if (slot2 == 2)
        {
            A_Slow_E2.SetActive(true);
        }
        else if (slot2 == 3)
        {
            A_Multi_E2.SetActive(true);
        }
        else if (slot2 == 4)
        {
            A_Invicibility_E2.SetActive(true);
        }
    }

    public void SetDouble()
    {
        if (A_Double)
        {
            if(slot1 != 1 && slot2 != 1) 
            {
                if (slot1 == -1)
                {
                    A_Double_E1.SetActive(true);
                    slot1 = 1;

                    QuickSaveWriter.Create("Player")
                              .Write("slot1", slot1)
                              .Commit();
                }
                else if (slot2 == -1)
                {
                    A_Double_E2.SetActive(true);
                    slot2 = 1;

                    QuickSaveWriter.Create("Player")
                              .Write("slot2", slot2)
                              .Commit();
                }
            }
            
        }
    }

    public void SetSlow()
    {
        if (A_Slow)
        {
            if (slot1 != 2 && slot2 != 2)
            {
                if (slot1 == -1)
                {
                    A_Slow_E1.SetActive(true);
                    slot1 = 2;

                    QuickSaveWriter.Create("Player")
                              .Write("slot1", slot1)
                              .Commit();
                }
                else if (slot2 == -1)
                {
                    A_Slow_E2.SetActive(true);
                    slot2 = 2;

                    QuickSaveWriter.Create("Player")
                              .Write("slot2", slot2)
                              .Commit();
                }
            }
        }
    }

    public void SetMulti()
    {
        if (A_Multi)
        {
            if (slot1 != 1 && slot2 != 1)
            {
                if (slot1 == -1)
                {
                    A_Multi_E1.SetActive(true);
                    slot1 = 3;

                    QuickSaveWriter.Create("Player")
                              .Write("slot1", slot1)
                              .Commit();
                }
                else if (slot2 == -1)
                {
                    A_Multi_E2.SetActive(true);
                    slot2 = 3;

                    QuickSaveWriter.Create("Player")
                              .Write("slot2", slot2)
                              .Commit();
                }
            }
        }
    }

    public void SetInvicibility()
    {
        if (A_Invicibility)
        {
            if (slot1 != 1 && slot2 != 1)
            {
                if (slot1 == -1)
                {
                    A_Invicibility_E1.SetActive(true);
                    slot1 = 4;

                    QuickSaveWriter.Create("Player")
                              .Write("slot1", slot1)
                              .Commit();
                }
                else if (slot2 == -1)
                {
                    A_Invicibility_E2.SetActive(true);
                    slot2 = 4;

                    QuickSaveWriter.Create("Player")
                              .Write("slot2", slot2)
                              .Commit();
                }
            }
        }
    }

    public void Romove1()
    {
        slot1 = -1;

        QuickSaveWriter.Create("Player")
                      .Write("slot1", slot1)
                      .Commit();

        A_Double_E1.SetActive(false);
        A_Slow_E1.SetActive(false);
        A_Multi_E1.SetActive(false);
        A_Invicibility_E1.SetActive(false);
    }

    public void Romove2()
    {
        slot2 = -1;

        QuickSaveWriter.Create("Player")
                      .Write("slot2", slot2)
                      .Commit();

        A_Double_E2.SetActive(false);
        A_Slow_E2.SetActive(false);
        A_Multi_E2.SetActive(false);
        A_Invicibility_E2.SetActive(false);
    }
}
