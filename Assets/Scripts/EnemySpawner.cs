using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Prefabs de los enemigos que se van a spawnear
    public GameObject whiteEnemyPrefab;
    public GameObject blackEnemyPrefab;
    
    // Array de posiciones de spawn
    public Transform[] spawnPoints;
    
    // Intervalo de tiempo entre spawns
    public float spawnInterval = 5f;
    
    // Variables para controlar el spawn procedural
    public int maxEnemies = 10; // Máximo número de enemigos en la escena
    private int currentEnemyCount = 0; // Contador de enemigos actuales
    private bool spawnWhiteEnemy = true; // Alternar entre enemigo blanco y negro

    void Start()
    {
        // Empezar a spawnear enemigos a intervalos regulares
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (currentEnemyCount < maxEnemies)
            {
                // Seleccionar un punto de spawn aleatorio
                int spawnIndex = Random.Range(0, spawnPoints.Length);
                Vector3 spawnPosition = spawnPoints[spawnIndex].position;

                // Alternar entre los dos tipos de enemigos
                if (spawnWhiteEnemy)
                {
                    Instantiate(whiteEnemyPrefab, spawnPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(blackEnemyPrefab, spawnPosition, Quaternion.identity);
                }

                // Alternar el tipo de enemigo para el próximo spawn
                spawnWhiteEnemy = !spawnWhiteEnemy;

                currentEnemyCount++;
            }

            // Esperar el intervalo de tiempo antes de spawnear el siguiente enemigo
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Método para reducir el contador de enemigos cuando un enemigo es destruido
    public void EnemyDestroyed()
    {
        currentEnemyCount--;
    }
}
