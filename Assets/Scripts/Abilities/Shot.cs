using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : Ability
{
    public GameObject prefab;
    public GameObject firePoint;

    public override void Activate(GameObject firePoint)
    {
        Instantiate(prefab, firePoint.transform.position, firePoint.transform.rotation);
    }
}
