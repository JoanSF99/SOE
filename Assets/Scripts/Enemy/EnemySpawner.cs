using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Asigna tu prefab de enemigo aquí
    public GameObject player; // Asigna tu objeto de jugador aquí
    public float spawnInterval = 2.0f; // Intervalo de tiempo entre spawns
    public float spawnDistance = 20.0f; // Distancia delante del jugador para spawnear enemigos
    public float laneDistance = 5.0f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 spawnPosition = player.transform.position + player.transform.forward * spawnDistance;
            spawnPosition.x = Random.Range(-1, 2) * laneDistance;
            spawnPosition.y = 8;
            GameObject obj = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0,180,0));
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
