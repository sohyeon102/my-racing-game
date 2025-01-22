using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    private float spawnTimer = 0f;
    private float nextSpawnTime = 0f;

    void Start()
    {
        SetRandimSpawnTime();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= nextSpawnTime)
        {
            SpawnObstacle();
            spawnTimer = 0f;
            SetRandimSpawnTime();
        }
        
    }

    void SpawnObstacle()
    {
        GameObject Obstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        
        float randomX = Random.Range(-1.5f, 1.5f);
        Vector3 spawnPos = new Vector3(randomX, 6.0f, 0.0f);
        
        Instantiate(Obstacle, spawnPos , Quaternion.Euler(180.0f, 0.0f, 0.0f));
    }

    void SetRandimSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
    
}
