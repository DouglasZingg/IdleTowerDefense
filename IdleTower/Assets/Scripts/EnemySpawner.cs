using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    public Transform[] spawnPoints;

    public float maxSpawnTime = 5.0f;
    public float minSpawnTime = 2.0f;
    public float spawnTime = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[randSpawnPoint].position, transform.rotation);

            SetTimeUntilSpawn();
        }

    }

    private void SetTimeUntilSpawn()
    {
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
