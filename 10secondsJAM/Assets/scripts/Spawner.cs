using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    float timeToNextSpawn;
    [SerializeField] float spawnRateInSeconds = 2f;
    [SerializeField] private EnemiesManager enemiesManager;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnNewEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemyByTime(spawnRateInSeconds);
        
    }

    void SpawnNewEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 11f, 0f);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy e = enemy.GetComponent<Enemy>();
        e.SetEmptyVariables_SafetyCheck();
        //e.PrintEnemyData();

        //add it to a list to keep track of it
        enemiesManager.AddEnemySpawnedToList(e);
    }

    void SpawnEnemyByTime(float time)
    {
        if (timeToNextSpawn >= time)
        {
            SpawnNewEnemy();
            timeToNextSpawn = 0f;
        }
        timeToNextSpawn += Time.deltaTime;
    }

}
