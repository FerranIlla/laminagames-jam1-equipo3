using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { None, Red, Green, Blue, Yellow}

public class Enemy : MonoBehaviour
{

    [HideInInspector] public EnemyType type = EnemyType.None;
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float minSpeed = 0.5f;
    [SerializeField] private float maxSpeed = 1f;
    [HideInInspector] public float health;
    [HideInInspector] public float startingHealth;


    EnemyAnimation enemyAnimation;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomMoveSpeed(minSpeed, maxSpeed);
        SetHealth(100f);

        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

        

    }

    void SetHealth(float healthValue)
    {
        health = healthValue;
        startingHealth = health;
    }

    void SetRandomType()
    {
        int randomNumber = UnityEngine.Random.Range(1, Enum.GetNames(typeof(EnemyType)).Length);
        type = (EnemyType)randomNumber;
    }

    void SetRandomMoveSpeed(float minSpeed, float maxSpeed)
    {
        moveSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    void MoveEnemy()
    {
        transform.Translate(new Vector3(0f, -moveSpeed * Time.deltaTime, 0f));
    }

    /// <summary>
    /// deal damage to this enemy and returns if it died
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    public bool GetHit(float damage)
    {
        //make bigger permanently
        enemyAnimation.IncreaseSize(startingHealth, health);
        //trigger animation
        enemyAnimation.TriggerHitAnimation();

        //health
        health -= damage;
        if(health <= 0)
        {
            return true;
        }

        return false;
    }

    public void PrintEnemyData()
    {
        Debug.Log("Enemy of type " + type.ToString());
        Debug.Log("Enemy falling speed: " + moveSpeed);
    }

    public void DeleteObject()
    {
        Destroy(gameObject);
    }
    
}
