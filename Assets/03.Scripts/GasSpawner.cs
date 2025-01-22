using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasSpawner : MonoBehaviour
{
    public GameObject gasPrefab;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;
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
            SpawnGas();
            spawnTimer = 0f;
            SetRandimSpawnTime();
        }
        
    }

    void SpawnGas()
    {
        float randomX = Random.Range(-1.5f, 1.5f);
        Vector3 spawnPos = new Vector3(randomX, 6.0f, 0.0f);
        
        Instantiate(gasPrefab, spawnPos , Quaternion.identity);
    }

    void SetRandimSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
    
}
