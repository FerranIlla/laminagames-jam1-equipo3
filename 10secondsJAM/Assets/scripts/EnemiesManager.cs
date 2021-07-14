using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [HideInInspector] public List<Enemy> enemiesRed = new List<Enemy>();
    [HideInInspector] public List<Enemy> enemiesGreen = new List<Enemy>();
    [HideInInspector] public List<Enemy> enemiesBlue = new List<Enemy>();
    [HideInInspector] public List<Enemy> enemiesYellow = new List<Enemy>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PrintListsSize();
        }
    }

    public void AddEnemySpawnedToList(Enemy enemySpawned)
    {
        switch (enemySpawned.type)
        {
            case EnemyType.Red:
                enemiesRed.Add(enemySpawned);
                break;
            case EnemyType.Green:
                enemiesGreen.Add(enemySpawned);
                break;
            case EnemyType.Blue:
                enemiesBlue.Add(enemySpawned);
                break;
            case EnemyType.Yellow:
                enemiesYellow.Add(enemySpawned);
                break;
            default:
                Debug.LogWarning("Not a known enemy type.");
                break;
        }
    }

    public void KillOneEnemy(Enemy enemyKilled)
    {
        switch (enemyKilled.type)
        {
            case EnemyType.Red:
                enemiesRed.Remove(enemyKilled);
                enemyKilled.DeleteObject();
                break;
            case EnemyType.Green:
                enemiesGreen.Remove(enemyKilled);
                enemyKilled.DeleteObject();
                break;
            case EnemyType.Blue:
                enemiesBlue.Remove(enemyKilled);
                enemyKilled.DeleteObject();
                break;
            case EnemyType.Yellow:
                enemiesYellow.Remove(enemyKilled);
                enemyKilled.DeleteObject();
                break;
            default:
                Debug.LogWarning("Not a known enemy type.");
                break;
        }
    }

    private void KillAllEnemiesFromList(List<Enemy> enemiesList)
    {
        for(int i = enemiesList.Count-1; i >= 0; i--)
        {
            Enemy e = enemiesList[i];
            enemiesList.Remove(e);
            e.DeleteObject();
        }
    }

    public void KillAllEnemies()
    {
        KillAllEnemiesFromList(enemiesRed);
        KillAllEnemiesFromList(enemiesGreen);
        KillAllEnemiesFromList(enemiesBlue);
        KillAllEnemiesFromList(enemiesYellow);
    }

    public void HitAllEnemiesOfType(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Red:
                KillAllEnemiesFromList(enemiesRed);
                break;
            case EnemyType.Green:
                KillAllEnemiesFromList(enemiesGreen);
                break;
            case EnemyType.Blue:
                KillAllEnemiesFromList(enemiesBlue);
                break;
            case EnemyType.Yellow:
                KillAllEnemiesFromList(enemiesYellow);
                break;
            default:
                Debug.LogWarning("Not a known enemy type.");
                break;
        }
    }



    void PrintListsSize()
    {
        Debug.Log("Number of enemies per type. R= " + enemiesRed.Count + " G= " + enemiesGreen.Count + " B= " + enemiesBlue.Count + " Y= " + enemiesYellow.Count);
    }
}
