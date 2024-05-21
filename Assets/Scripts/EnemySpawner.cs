using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject blackEnemyPrefab;
    public GameObject whiteEnemyPrefab;
    public float spawnRate = 2f;
    private float nextSpawn;

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
        Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 10f, 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}

