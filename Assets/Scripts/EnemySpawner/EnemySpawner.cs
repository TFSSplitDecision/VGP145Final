using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WaveSpawn
{
    public float[] chances;
    public int GetRandomEnemyIndex()
    {
        float rand = Random.value;
        float accum = 0.0f;
        for( int i=0; i< chances.Length; i++ )
        {
            if (rand < chances[i] + accum)
                return i;
            accum += chances[i];
        }
        // Fallback
        return 0;
    }
}

public class EnemySpawner : MonoBehaviour
{

    public WaveSpawn[] waveSpawns;

    [Header("Parameters")]

    public GameObject[] spawners;
    public GameObject[] enemyPrefabs;
    [SerializeField, SceneEditOnly] private int maxWaves = 10; // Maximum number of waves
    [SerializeField, SceneEditOnly] private float initialTimer = 10f; // Initial timer for the first wave
    [SerializeField, SceneEditOnly] private float setTimer = 20f; // Timer for subsequent waves


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
        waveNumber = 1;
    }

    void Update()
    {
        waveTimer -= Time.deltaTime;
        bool firstWave = (waveNumber == 1);
        bool timerEnded = waveTimer <= 0;
        bool noEnemies = activeEnemies.Count == 0;
        bool moreWavesRemain = waveNumber <= maxWaves;
        if (moreWavesRemain && ((firstWave && timerEnded) || (!firstWave && (timerEnded || noEnemies) )))
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
        if (waveNumber > waveSpawns.Length)
            waveNumber = waveSpawns.Length;

        WaveSpawn waveSpawn = waveSpawns[waveNumber-1];
        int enemyIndex = waveSpawn.GetRandomEnemyIndex();
        enemyIndex = Mathf.Clamp(enemyIndex, 0, enemyPrefabs.Length - 1);
        return enemyPrefabs[enemyIndex];
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
