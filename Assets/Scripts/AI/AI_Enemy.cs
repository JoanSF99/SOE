using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using TMPro;

public class AI_Enemy : Agent
{
    private int lane = 1; // 0 = izquierda, 1 = centro, 2 = derecha
    public float speed = 5;
    public float laneDistance = 5.0f; // distancia entre carriles
    public float jumpForce = 2.0f; // fuerza del salto
    private bool isJumping = false; // si el objeto está saltando

    private float timeInSameLane = 0f;
    private int previousLane;

    public GameObject firePoint; // Punto de origen del disparo
    public Ability[] abilities;
    private float fireTimer = 0f; // Temporizador de disparo
    public float fireInterval = 2.0f; // Intervalo de disparo

    public bool trainingMode;

    new private Rigidbody rigidbody;

    GameObject player;

    private bool frozen = false;

    public float PointsObtained { get; private set; }

    public override void Initialize()
    {
        rigidbody = GetComponent<Rigidbody>();

        if (!trainingMode) MaxStep = 0;

        // Buscar al jugador en la escena por su tag
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                //Debug.LogError("No se pudo encontrar un objeto con el tag 'Player' en la escena.");
            }
            else
            {
                //Debug.Log("Referencia del jugador asignada correctamente.");
            }
        }
    }

    public override void OnEpisodeBegin()
    {
        if (trainingMode && player != null)
        {
            player.GetComponent<AI_Player>().ResetPlayer();
        }

        PointsObtained = 0;

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        lane = 1; // Reset to center lane
        isJumping = false; // Reset jumping state

        timeInSameLane = 0f;
        previousLane = lane;

        //Debug.Log("Episode Begin: Resetting lane to center and jumping state to false");

        // Reafirmar la referencia al jugador al inicio de cada episodio
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                //Debug.LogError("No se pudo encontrar un objeto con el tag 'Player' en la escena.");
            }
            else
            {
                //Debug.Log("Referencia del jugador asignada correctamente al inicio del episodio.");
            }
        }
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (frozen) return;

        // Obtener las acciones
        float moveHorizontal = actions.ContinuousActions[0];
        float jumpAction = actions.ContinuousActions[1];

        // Ajustar el carril basado en la acción horizontal
        if (moveHorizontal < -0.5f && lane > 0)
        {
            lane--;
        }
        else if (moveHorizontal > 0.5f && lane < 2)
        {
            lane++;
        }

        // Limitar el movimiento horizontal a los carriles definidos
        lane = Mathf.Clamp(lane, 0, 2);

        // Calcular la posición objetivo para el carril sin cambiar la Z
        Vector3 targetPosition = new Vector3((lane - 1) * laneDistance, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Manejar el salto
        if (jumpAction > 0.5f && !isJumping)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
        if (lane == previousLane)
        {
            timeInSameLane += Time.deltaTime;
            if (timeInSameLane > 3f)
            {
                AddReward(-0.5f); // Penalización
                timeInSameLane = 0f; // Reiniciar el temporizador
            }
        }
        else
        {
            timeInSameLane = 0f; // Reiniciar el temporizador
        }

        previousLane = lane;

        // Manejar el disparo
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireInterval)
        {
            abilities[0].Activate(firePoint);
            fireTimer = 0;
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Observación de la posición del enemigo (incluye Z)
        sensor.AddObservation(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z));

        // Observación de la velocidad del enemigo (incluye Z)
        sensor.AddObservation(new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z));

        // Observación de si el enemigo está saltando
        sensor.AddObservation(isJumping);

        // Observación de la posición del jugador (incluye Z)
        if (player != null)
        {
            sensor.AddObservation(new Vector3(player.transform.localPosition.x, player.transform.localPosition.y, player.transform.localPosition.z));
        }

        // Observación de la distancia entre el enemigo y el jugador (incluye Z)
        if (player != null)
        {
            Vector3 distanceToPlayer = player.transform.localPosition - transform.localPosition;
            sensor.AddObservation(distanceToPlayer);
        }

        // Observación del carril actual del enemigo
        sensor.AddObservation(lane);

        // Imprimir las observaciones para depuración
        //Debug.Log($"Observaciones - Posición: {new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z)}, " +
                  //$"Velocidad: {new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z)}, Saltando: {isJumping}, " +
                  //$"Carril: {lane}, Distancia al jugador: {distanceToPlayer}");
    }


    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActions = actionsOut.ContinuousActions;
        continuousActions.Clear();

        float moveHorizontal = 0f;
        float jump = 0f;

        // Convertir entradas de teclado a movimientos
        if (Input.GetKey(KeyCode.LeftArrow)) moveHorizontal = -1f; // Mover a la izquierda
        else if (Input.GetKey(KeyCode.RightArrow)) moveHorizontal = 1f; // Mover a la derecha

        // Saltar
        if (Input.GetKey(KeyCode.Space)) jump = 1f;

        // Asignar valores al arreglo de acciones
        continuousActions[0] = moveHorizontal;
        continuousActions[1] = jump;
    }

    public void FreezeAgent()
    {
        //Debug.Assert(trainingMode == false, "Freeze/Unfreeze not supported in training");
        frozen = true;
        rigidbody.Sleep();
    }

    public void UnfreezeAgent()
    {
        //Debug.Assert(trainingMode == false, "Freeze/Unfreeze not supported in training");
        frozen = false;
        rigidbody.WakeUp();
    }

    public void AddReward_()
    {
        AddReward(.2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (trainingMode && collision.collider.CompareTag("bullet"))
        {
            AddReward(-.5f);
            //Debug.Log("Colisión con bala detectada, recompensa negativa añadida.");
        }
        if (trainingMode && collision.collider.CompareTag("Player"))
        {
            AddReward(1f);
            //Debug.Log("Colisión con jugador detectada, recompensa positiva añadida.");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isJumping = false;
            //Debug.Log("En contacto con el suelo: isJumping = false");
        }
    }
}
