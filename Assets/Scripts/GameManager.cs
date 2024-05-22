using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        
        // Generar posición aleatoria en el suelo
        float spawnXPosition = Random.Range(-8f, 8f); // Ajustar valores según el tamaño de tu área de juego
        float spawnZPosition = Random.Range(-8f, 8f); // Ajustar valores según el tamaño de tu área de juego
        Vector3 spawnPosition = new Vector3(spawnXPosition, 0.5f, spawnZPosition); // Ajustar la posición Y según el suelo

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
