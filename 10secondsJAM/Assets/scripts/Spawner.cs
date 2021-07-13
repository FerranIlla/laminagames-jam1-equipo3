using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    float timeToNextSpawn;
    float spawnRateInSeconds = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToNextSpawn >= spawnRateInSeconds)
        {
            SpawnNewEnemy();
            timeToNextSpawn = 0f;
        }
        timeToNextSpawn += Time.deltaTime;
    }

    void SpawnNewEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 11f, 0f);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy e = enemy.GetComponent<Enemy>();
        e.SetEmptyVariables_SafetyCheck();
        e.PrintEnemyData();
    }
}
