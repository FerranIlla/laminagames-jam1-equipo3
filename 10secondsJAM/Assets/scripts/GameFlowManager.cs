using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Presentation, Gameplay, Defeat, Victory}

public class GameFlowManager : MonoBehaviour
{

    [HideInInspector]public GameState gameState;

    //all manager references
    [SerializeField] private EnemiesManager enemiesManager;
    [SerializeField] private Spawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        //Set first game state
        gameState = GameState.Gameplay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DefeatEvent()
    {
        if (gameState == GameState.Gameplay)
        {
            Debug.Log("You are defeated! :_(");
            gameState = GameState.Defeat;
            enemySpawner.StopSpawning();
            enemiesManager.KillAllEnemies();
        }
    }

    public void VictoryEvent()
    {
        if (gameState == GameState.Gameplay)
        {
            Debug.Log("You are victorious! :D");
            gameState = GameState.Victory;
            enemySpawner.StopSpawning();
            enemiesManager.KillAllEnemies();
        }
    }
}
