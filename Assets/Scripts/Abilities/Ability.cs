using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public abstract void Activate(GameObject firePoint);

    public int manaCost;
}
