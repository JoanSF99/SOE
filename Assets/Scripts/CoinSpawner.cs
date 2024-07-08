using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Asigna tu prefab de moneda aquí
    public GameObject player; // Asigna tu objeto de jugador aquí
    public float spawnInterval = 1.0f; // Intervalo de tiempo entre spawns
    public float spawnDistance = 20.0f; // Distancia delante del jugador para spawnear monedas
    public float laneDistance = 5.0f;

    void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            Vector3 spawnPosition = player.transform.position + player.transform.forward * spawnDistance;
            spawnPosition.x = Random.Range(-1, 2) * laneDistance;
            spawnPosition.y = 7;
            GameObject obj = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
