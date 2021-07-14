using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private EnemiesManager enemiesManager;
    private GameFlowManager gameFlowManager;
    private LivesVisualizer livesVisualizer;
    [HideInInspector] public int lives;

    // Start is called before the first frame update
    void Start()
    {
        gameFlowManager = GameObject.FindWithTag("GameController").GetComponent<GameFlowManager>();
        livesVisualizer = GetComponent<LivesVisualizer>();

        //Set starting lives
        lives = 8;
        livesVisualizer.RecalculateVisualizer(lives);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy e = other.GetComponent<Enemy>(); //get enemy script reference
            
            lives = lives - 1; //lose hp/points
            if (lives <= 0) gameFlowManager.DefeatEvent();
            //feedback/animation/sound
            livesVisualizer.RecalculateVisualizer(lives);

            enemiesManager.KillOneEnemy(e);
        }
    }
}
