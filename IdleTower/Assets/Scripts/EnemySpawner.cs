using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private float _maximumSpawnTime;
    private float _timeUntilSpawn;

    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> spawnLocations = new List<GameObject>();

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if(_timeUntilSpawn <= 0 && enemies.Count < 10)
        {
            int rand = Random.Range(0, 12);
            Instantiate(_enemyPrefab, spawnLocations[rand].transform.position, Quaternion.identity);
            enemies.Add(_enemyPrefab);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

    public void AmDead(GameObject enemy)
    {
        //for(int i = 0; i < enemies.Count; i++)
        //{
        //    if(enemies[i] == enemy)
        //    {
                enemies.RemoveAt(0);
                //Destroy(enemy);
        //    }
        //}
    }
}
