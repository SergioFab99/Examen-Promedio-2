using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject blackEnemyPrefab;
    public GameObject whiteEnemyPrefab;
    public float spawnRate = 2f;
    private float nextSpawn;

    void Start()
    {
        nextSpawn = Time.time + spawnRate;
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int enemyType = Random.Range(0, 2);
        GameObject enemyPrefab = (enemyType == 0) ? blackEnemyPrefab : whiteEnemyPrefab;
        
        // Generar posición aleatoria en la parte superior de la pantalla
        float spawnXPosition = Random.Range(-8f, 8f); // Ajustar valores según el tamaño de tu pantalla de juego
        Vector3 spawnPosition = new Vector3(spawnXPosition, 10f, 0f); // Ajustar la posición Y según tu escena

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}