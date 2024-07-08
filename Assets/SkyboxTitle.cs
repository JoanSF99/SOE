using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTitle : MonoBehaviour
{
    public float skyboxSpeed = 0.001f;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxSpeed);
    }
}
