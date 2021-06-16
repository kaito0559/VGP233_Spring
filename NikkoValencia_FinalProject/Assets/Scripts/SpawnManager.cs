using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject enemyPrefab;
    private float startDelay = 0.0f;
    private float repeatRate = 3.5f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnEnemy", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void SpawnObstacle()
    {
        Vector3 spawnLocation = new Vector3(35.0f, 0.94f, -0.04f);
        int index = Random.Range(0, 5);

        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefabs[index], spawnLocation, obstaclePrefabs[index].transform.rotation);
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnLocation = new Vector3(-7, 5, 0);
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(enemyPrefab, spawnLocation, enemyPrefab.transform.rotation);
        }
    }
}
