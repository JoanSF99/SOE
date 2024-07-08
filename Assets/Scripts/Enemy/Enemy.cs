using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;
    public float speed = 5;
    private int lane = 1; // 0 = izquierda, 1 = centro, 2 = derecha
    public static float laneDistance = 5.0f; // distancia entre carriles
    private float switchLaneTimer = 0; // temporizador para cambiar de carril
    public float switchLaneInterval = 2.0f; // intervalo para cambiar de carril

    public GameObject firePoint; // Punto de origen del disparo
    public Ability[] abilities;
    private float fireTimer = 0f; // Temporizador de disparo
    public float fireInterval = 2.0f; // Intervalo de disparo

    void Update()
    {
        // Cambiar de carril aleatoriamente
        switchLaneTimer += Time.deltaTime;
        if (switchLaneTimer > switchLaneInterval)
        {
            lane = Random.Range(0, 3); // seleccionar un carril aleatorio
            switchLaneTimer = 0;
        }

        Vector3 targetPosition = transform.position;
        targetPosition.x = (lane - 1) * laneDistance; // los carriles están ahora a una distancia de 'laneDistance' entre sí

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Manejar el disparo
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireInterval)
        {
            abilities[0].Activate(firePoint);
            fireTimer = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow()
    {
        speed /= 2.0f;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(1);

            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
