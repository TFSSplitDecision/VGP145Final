using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Parameters")]
    public GameObject[] spawners;
    public GameObject[] enemyPrefabs;
    private int maxWaves = 10; // Maximum number of waves
    private float initialTimer = 10f; // Initial timer for the first wave
    private float setTimer = 20f; // Timer for subsequent waves

    [Header("Variables")]
    private int waveNumber = 1; // Start counting from wave 1
    private float waveTimer;
    private bool firstWaveSpawned = false;
    private int baseEnemyCount = 10; // Base number of enemies to spawn
    private List<GameObject> activeEnemies = new List<GameObject>();
    // Getters
    public int curEnemyCount => activeEnemies.Count;
    public int curWaveNumber => waveNumber;
    public float curWaveTimer => waveTimer;

    private void Start()
    {
        waveTimer = initialTimer; // Set to initial timer for the first wave
    }

    private void OnValidate()
    {
        if (waveNumber < 1) // Ensure waveNumber is never less than 1
        {
            waveNumber = 1;
        }
    }
     
    void Update()
    {
        waveTimer -= Time.deltaTime;

        if (!firstWaveSpawned && waveTimer <= 0)
        {
            SpawnEnemies();
            firstWaveSpawned = true;
            waveTimer = setTimer; // Reset the timer for subsequent waves
        }
        else if (firstWaveSpawned && waveNumber <= maxWaves && (activeEnemies.Count == 0 || waveTimer <= 0))
        {
            SpawnEnemies();
            waveNumber++;
            waveTimer = setTimer;
        }

        RemoveDestroyedEnemies();
    }

    void SpawnEnemies()
    {
        if (waveNumber > maxWaves) return; // Stop after maxWaves

        int enemyCount = baseEnemyCount + ((waveNumber - 1) * 2); // Adjust formula for enemies

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemyToSpawn = SelectEnemyForWave(waveNumber);
            GameObject spawnedEnemy = Instantiate(enemyToSpawn, GetRandomSpawnerPosition(), Quaternion.identity);
            activeEnemies.Add(spawnedEnemy);
        }
    }

    GameObject SelectEnemyForWave(int waveNumber)
    {
        if (waveNumber == 1) // Wave 1 spawns only enemy 1
        {
            return enemyPrefabs[0];
        }
        else if (waveNumber == 2) // Wave 2 spawns enemies 1 and 2 randomly
        {
            return enemyPrefabs[Random.Range(0, 2)];
        }
        else // Wave 3 and beyond
        {
            float randomValue = Random.value; // Generates a random number between 0.0 and 1.0
            if (randomValue < 0.7) // 70% chance to spawn enemy 1
            {
                return enemyPrefabs[0];
            }
            else // 30% chance to spawn enemy 2 or 3
            {
                return enemyPrefabs[Random.Range(1, enemyPrefabs.Length)]; // Selects either enemy 2 or 3
            }
        }
    }

    Vector3 GetRandomSpawnerPosition()
    {
        int randomIndex = Random.Range(0, spawners.Length);
        return spawners[randomIndex].transform.position;
    }

    void RemoveDestroyedEnemies()
    {
        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            if (activeEnemies[i] == null)
            {
                activeEnemies.RemoveAt(i);
            }
        }
    }
}
