using CI.QuickSave;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverPointsText;
    public TextMeshProUGUI gameOverDistanceText;
    public GameObject recordPanel;

    public TextMeshProUGUI healthText;

    public bool invincible = false;

    public float totalPoints;
    public float recordDistance;

    Player player;

    private void Start()
    {
        player = GetComponent<Player>();

        healthText.text = player.health.ToString();

        recordPanel.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        if (!invincible)
        {
            player.health -= damage;

            healthText.text = player.health.ToString();

            if (player.health <= 0)
            {
                Die();
            }
        }
    }

    public void BecomeInvincible(float time)
    {
        StartCoroutine(BecomeInvincibleE(time));
    }

    private IEnumerator BecomeInvincibleE(float time)
    {
        invincible = true;

        yield return new WaitForSeconds(time);

        invincible = false;
    }

    private void Die()
    {
        QuickSaveReader.Create("Player")
                    .Read<float>("totalPoints", (r) => { totalPoints = r; })
                    .Read<float>("recordDistance", (r) => { recordDistance = r; });

        // Sumar los puntos al total de puntos
        totalPoints += player.points;

        


        gameOverPanel.SetActive(true);
        gameOverPointsText.text = player.points.ToString();
        
        float displayDistance = player.distance / 10f;
        if (displayDistance >= 100f)
        {
            gameOverDistanceText.text = Mathf.Floor(displayDistance).ToString();
        }
        else
        {
            gameOverDistanceText.text = displayDistance.ToString("F1");
        }

        if(player.distance > recordDistance)
        {
            recordPanel.SetActive(true);
            recordDistance = player.distance;
        }

        QuickSaveWriter.Create("Player")
                    .Write("totalPoints", totalPoints)
                    .Write("recordDistance", recordDistance)
                    .Commit();

        Time.timeScale = 0;
    }
}
