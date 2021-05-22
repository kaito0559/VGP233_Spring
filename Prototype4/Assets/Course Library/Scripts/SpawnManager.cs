using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    private float spawnRange = 5.0f;
    private int waveNumber = 1;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = 2.4f;
        return new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    }

    void SpawnEnemyWave(int numberOfEnemies)
    {
        for(int i = 0; i < numberOfEnemies; ++i)
        {
            Instantiate(enemyPrefab, (GenerateSpawnPosition()), enemyPrefab.transform.rotation);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(++waveNumber);
        }
    }
}
