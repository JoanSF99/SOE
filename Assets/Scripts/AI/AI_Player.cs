using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Player : MonoBehaviour
{
    public float speed = 5;
    private int lane = 1; // 0 = izquierda, 1 = centro, 2 = derecha
    public float laneDistance = 5.0f; // distancia entre carriles
    public float jumpForce = 2.0f; // fuerza del salto
    private bool isJumping = false; // si el objeto está saltando
    private float switchLaneTimer = 0; // temporizador para cambiar de carril
    public float switchLaneInterval = 2.0f; // intervalo para cambiar de carril
    public float fireInterval = 1.0f; // intervalo para disparar
    private float fireTimer = 0; // temporizador para disparar
    private Vector3 initialPosition;

    private Rigidbody playerRigidbody;
    private Collider playerCollider;
    
    public Ability[] abilities;

    public GameObject firePoint;

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

        // Mover al jugador hacia el carril objetivo
        Vector3 lateralMove = Vector3.MoveTowards(new Vector3(transform.position.x, 0, 0), new Vector3(targetPosition.x, 0, 0), speed * Time.deltaTime);
        transform.position = new Vector3(lateralMove.x, transform.position.y, transform.position.z);

        // Mover al jugador hacia adelante
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);

        // Hacer que el jugador salte
        if (!isJumping && Random.Range(0f, 1f) < 0.1f) // 10% de probabilidad de saltar
        {
            Debug.Log("salta");
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }

        // Hacer que el jugador dispare aleatoriamente
        fireTimer += Time.deltaTime;
        if (fireTimer > fireInterval)
        {
            abilities[0].Activate(firePoint);
            fireTimer = 0;
        }
    }

    public void ResetPlayer()
    {
        playerCollider.gameObject.SetActive(true);

        transform.position = initialPosition;
    }

    private void Awake()
    {
        initialPosition = transform.position;

        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si el jugador toca el suelo, puede saltar de nuevo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
