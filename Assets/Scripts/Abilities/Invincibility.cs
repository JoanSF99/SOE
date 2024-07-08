using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : Ability
{
    public float duration = 10;

    public override void Activate(GameObject firePoint)
    {

        GameObject player = firePoint.transform.parent.gameObject;

        Health health = player.GetComponent<Health>();

        health.BecomeInvincible(duration);
    }
}
