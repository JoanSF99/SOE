using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 50.0f; // Velocidad de rotaci�n de la moneda

    void Update()
    {
        // Hace girar la moneda
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Comprueba si el jugador ha recogido la moneda
        if (other.gameObject.CompareTag("Player"))
        {
            // Aqu� puedes incrementar la puntuaci�n del jugador
            other.gameObject.GetComponent<Points>().AddPoints(1);

            // Destruye la moneda
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
