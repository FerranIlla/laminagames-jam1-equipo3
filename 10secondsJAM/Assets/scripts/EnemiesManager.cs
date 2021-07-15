using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [HideInInspector] public List<Enemy> enemiesRed = new List<Enemy>();
    [HideInInspector] public List<Enemy> enemiesGreen = new List<Enemy>();
    [HideInInspector] public List<Enemy> enemiesBlue = new List<Enemy>();
    [HideInInspector] public List<Enemy> enemiesYellow = new List<Enemy>();

    private GameFlowManager gameFlowManager;

    // Start is called before the first frame update
    void Start()
    {
        gameFlowManager = GameObject.FindWithTag("GameController").GetComponent<GameFlowManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    PrintListsSize();
        //}
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

    /// <summary>
    /// Deletes an enemy without adding it to the kill count.
    /// </summary>
    /// <param name="enemyToDelete"></param>
    public void DeleteOneEnemy(Enemy enemyToDelete)
    {
        switch (enemyToDelete.type)
        {
            case EnemyType.Red:
                enemiesRed.Remove(enemyToDelete);
                enemyToDelete.DeleteObjectWithoutConfetti();
                break;
            case EnemyType.Green:
                enemiesGreen.Remove(enemyToDelete);
                enemyToDelete.DeleteObjectWithoutConfetti();
                break;
            case EnemyType.Blue:
                enemiesBlue.Remove(enemyToDelete);
                enemyToDelete.DeleteObjectWithoutConfetti();
                break;
            case EnemyType.Yellow:
                enemiesYellow.Remove(enemyToDelete);
                enemyToDelete.DeleteObjectWithoutConfetti();
                break;
            default:
                Debug.LogWarning("Not a known enemy type.");
                break;
        }
    }

    /// <summary>
    /// Deletes an enemy and adds 1 to the kill count.
    /// </summary>
    /// <param name="enemyKilled"></param>
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
        gameFlowManager.AddEnemiesKilledToCount(1);

    }

    private void KillAllEnemiesFromList(List<Enemy> enemiesList)
    {
        gameFlowManager.AddEnemiesKilledToCount(enemiesList.Count);

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
