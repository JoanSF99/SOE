using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public  float forwardSpeed = 50.0f; // velocidad de movimiento hacia adelante
    private int lane = 1; // 0 = izquierda, 1 = centro, 2 = derecha
    public float laneDistance = 5.0f; // distancia entre carriles
    public float jumpForce = 2.0f; // fuerza del salto
    private bool isJumping = false; // si el objeto está saltando

    private CapsuleCollider playerCollider; // referencia al collider del jugador
    private float originalColliderSize; // tamaño original del collider
    private float slideColliderSize; // tamaño del collider 
    private Vector3 originalColliderCenter;

    private Animator animator;

    private Player player;

    void Start()
    {
        // Obtener el collider del jugador y guardar su tamaño original
        playerCollider = GetComponent<CapsuleCollider>();
        originalColliderSize = playerCollider.height;
        slideColliderSize = originalColliderSize / 2;
        originalColliderCenter = playerCollider.center;

        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && lane > 0)
        {
            lane--;
        }
        else if (Input.GetKeyDown(KeyCode.D) && lane < 2)
        {
            lane++;
        }

        Vector3 targetPosition = transform.position;
        targetPosition.x = (lane - 1) * laneDistance; // los carriles están ahora a una distancia de 'laneDistance' entre sí

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, forwardSpeed * Time.deltaTime);

        // Mover hacia adelante todo el rato
        transform.Translate(0, 0, forwardSpeed * Time.deltaTime);
        player.distance += forwardSpeed * Time.deltaTime;

        // Saltar cuando se presiona la flecha hacia arriba
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            GetComponent<Rigidbody>().AddForce(0, jumpForce, 0, ForceMode.Impulse);
            isJumping = true;

            animator.SetTrigger("Jump");
        }

        /*if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerCollider.center = new Vector3(originalColliderCenter.x, originalColliderCenter.y - (slideColliderSize/2), originalColliderCenter.z);
            playerCollider.height = originalColliderSize - slideColliderSize; // reducir el tamaño del collider
            
        }

        // Volver al tamaño original del collider cuando se suelta la flecha hacia abajo
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerCollider.center = originalColliderCenter;
            playerCollider.height = originalColliderSize; // restaurar el tamaño original del collider
        }*/
    }

    // Detectar cuando el objeto toca el suelo
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetTrigger("Landing");

            isJumping = false;

            
        }
    }
}
