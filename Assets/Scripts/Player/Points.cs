using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    private int pointValue = 1;
    public TextMeshProUGUI pointsText;

    Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void AddPoints(int points)
    {
        player.points += points * pointValue;
        pointsText.text = player.points.ToString();
    }

    public void MultiplyPoints(float time)
    {
       StartCoroutine(DoubleCoinE(time));
    }

    private IEnumerator DoubleCoinE(float time)
    {
        pointValue = 2;

        yield return new WaitForSeconds(time);

        pointValue = 1;
    }
}
