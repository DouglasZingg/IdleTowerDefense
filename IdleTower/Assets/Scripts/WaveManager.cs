using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform[] spawnPoints;

    public float spawnTime = 0.0f;

    public int wave = 1;
    private int waveValue;
    public int waveDuration;
    private float waveTimer;
    private int nextEnemy = 0;
    public float spawnInterval;

    public TMP_Text waveText;
    public TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        GenerateWaves();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime <= 0)
        {
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            if (nextEnemy != enemiesToSpawn.Count)
            {
                Instantiate(enemiesToSpawn[nextEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
                nextEnemy++;
                spawnTime = spawnInterval;
            }
            else
            {
                nextEnemy = 0;
                wave++;
                GenerateWaves();
            }
        }
        
        waveTimer -= Time.deltaTime;
        spawnTime -= Time.deltaTime;

        waveText.text = "Wave: " + wave.ToString();
        timeText.text = "Time Left: " + waveTimer.ToString("F0");
    }

    public void GenerateWaves()
    {
        waveValue = wave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration; // wave duration is read only
    }

    public void GenerateEnemies()
    {
        // Create a temporary list of enemies to generate
        // 
        // in a loop grab a random enemy 
        // see if we can afford it
        // if we can, add it to our list, and deduct the cost.

        // repeat... 

        //  -> if we have no points left, leave the loop

        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0 || generatedEnemies.Count < 50)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost = 0;
}
