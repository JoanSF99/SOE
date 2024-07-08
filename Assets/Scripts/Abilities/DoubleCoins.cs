using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCoins : Ability
{
    public float duration = 10;

    public override void Activate(GameObject firePoint)
    {
        GameObject player = firePoint.transform.parent.gameObject;

        Points points = player.GetComponent<Points>();

        points.MultiplyPoints(duration);
    }
}
