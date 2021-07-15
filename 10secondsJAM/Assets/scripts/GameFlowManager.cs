using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Presentation, Gameplay, Defeat, Victory}

public class GameFlowManager : MonoBehaviour
{

    [HideInInspector]public GameState gameState;
    [Tooltip("If true, victory is achieved by surviving 'secondsToSurvive' time. Otherwise, it is achieved by killing 'enemiesToKill' number of enemies.")]
    public bool victoryByTime = true; //otherwise, victory by balloons poped.
    public float secondsToSurvive = 90; //inSeconds
    public int enemiesToKill = 30;
    private float timeSurvived = 0;
    private int enemiesKilled = 0;


    //all manager references
    [SerializeField] private EnemiesManager enemiesManager;
    [SerializeField] private Spawner enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        //Set first game state
        gameState = GameState.Gameplay;
        AudioManager.instance.PlaySound("BattleMusic");
    }

    // Update is called once per frame
    void Update()
    {
        CheckVictoryCondition();
    }

    private void CheckVictoryCondition()
    {
        if (victoryByTime)
        {
            if (timeSurvived >= secondsToSurvive)
            {
                //win
                VictoryEvent();
            }
            timeSurvived += Time.deltaTime;
        }
        else
        {
            if(enemiesKilled >= enemiesToKill)
            {
                //win
                VictoryEvent();
            }
        }
    }

    public void AddEnemiesKilledToCount(int numberOfEnemiesKilled)
    {
        enemiesKilled += numberOfEnemiesKilled;
    }

    public void DefeatEvent()
    {
        if (gameState == GameState.Gameplay)
        {
            Debug.Log("You are defeated! :_(");
            AudioManager.instance.PlaySound("Defeat");
            gameState = GameState.Defeat;
            //enemySpawner.StopSpawning();
            //enemiesManager.KillAllEnemies();
        }
    }

    public void VictoryEvent()
    {
        if (gameState == GameState.Gameplay)
        {
            Debug.Log("You are victorious! :D");
            AudioManager.instance.PlaySound("Victory");
            gameState = GameState.Victory;
            enemySpawner.StopSpawning();
            enemiesManager.KillAllEnemies();
        }
    }
}
