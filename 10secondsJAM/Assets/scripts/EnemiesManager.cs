using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [HideInInspector] public List<Enemy> enemiesA = new List<Enemy>();
    [HideInInspector] public List<Enemy> enemiesB = new List<Enemy>();
    [HideInInspector] public List<Enemy> enemiesC = new List<Enemy>();
    [HideInInspector] public List<Enemy> enemiesD = new List<Enemy>();


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
                enemiesA.Add(enemySpawned);
                break;
            case EnemyType.Green:
                enemiesB.Add(enemySpawned);
                break;
            case EnemyType.Blue:
                enemiesC.Add(enemySpawned);
                break;
            case EnemyType.Yellow:
                enemiesD.Add(enemySpawned);
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
                enemiesA.Remove(enemyKilled);
                enemyKilled.DeleteObject();
                break;
            case EnemyType.Green:
                enemiesB.Remove(enemyKilled);
                enemyKilled.DeleteObject();
                break;
            case EnemyType.Blue:
                enemiesC.Remove(enemyKilled);
                enemyKilled.DeleteObject();
                break;
            case EnemyType.Yellow:
                enemiesD.Remove(enemyKilled);
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

    public void HitAllEnemiesOfType(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Red:
                KillAllEnemiesFromList(enemiesA);
                break;
            case EnemyType.Green:
                KillAllEnemiesFromList(enemiesB);
                break;
            case EnemyType.Blue:
                KillAllEnemiesFromList(enemiesC);
                break;
            case EnemyType.Yellow:
                KillAllEnemiesFromList(enemiesD);
                break;
            default:
                Debug.LogWarning("Not a known enemy type.");
                break;
        }
    }

    void PrintListsSize()
    {
        Debug.Log("Number of enemies per type. R= " + enemiesA.Count + " G= " + enemiesB.Count + " B= " + enemiesC.Count + " Y= " + enemiesD.Count);
    }
}
