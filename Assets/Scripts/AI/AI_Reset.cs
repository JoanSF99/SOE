using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Reset : MonoBehaviour
{
    public AI_Player player;
    public AI_Enemy enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.ResetPlayer();
        }
        else if (collision.gameObject.CompareTag("bullet"))
        {
            enemy.AddReward_();
        }
    }
}
