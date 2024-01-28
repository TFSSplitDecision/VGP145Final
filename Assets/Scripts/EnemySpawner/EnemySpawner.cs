using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Parameters")]
    // Spawn points
    public GameObject[] spawners;
    // Enemy prefabs
    public GameObject[] enemyPrefabs;

    [SerializeField]
    private int maxWaves = 10; // Maximum number of waves
    
    [SerializeField]
    private float setTimer = 10f;



   
    [Header("Variables")]

    [SerializeField]
    private int waveNumber = 0;
    [SerializeField, Range(0.0f,30.0f)]
    private float waveTimer = 10f;
    

    // Wave timer
    [SerializeField]
    private int baseEnemyCount = 10; // Base number of enemies to spawn

    [SerializeField]
    private List<GameObject> activeEnemies = new List<GameObject>();


    // Getters
    public int curEnemyCount => activeEnemies.Count;
    public int curWaveNumber => waveNumber;

    public float curWaveTimer => waveTimer;


    private void OnValidate()
    {
        
        if( waveNumber < 0 )
        {
            Debug.LogError("Wave number is negative");
            waveNumber = 0;
        }
        

    }

    void Update()
    {
        waveTimer -= Time.deltaTime;


        if (waveNumber < maxWaves && (activeEnemies.Count == 0 || waveTimer <= 0))  // checks the list if all enemies are destroyed or if the wavetimer is up
        {
            waveNumber++;
            SpawnEnemies();
            Debug.Log("New Wave Started: Wave Number " + waveNumber);
            waveTimer = setTimer; // Reset the timer for the next wave
        }


        RemoveDestroyedEnemies();
    }

    void SpawnEnemies()
    {
        if (waveNumber > maxWaves) return; // Stop after maxWaves

        int enemyCount = baseEnemyCount + (waveNumber * 2); // Formula for enemies 

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemyToSpawn = SelectEnemyForWave(waveNumber);
            GameObject spawnedEnemy = Instantiate(enemyToSpawn, GetRandomSpawnerPosition(), Quaternion.identity);
            activeEnemies.Add(spawnedEnemy);
            Debug.Log("Spawned Enemy: " + spawnedEnemy.name + " (Wave " + waveNumber + ")");
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
