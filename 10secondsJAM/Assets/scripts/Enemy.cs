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
    [HideInInspector] public int health;

    // Start is called before the first frame update
    void Start()
    {
        SetEmptyVariables_SafetyCheck();
        //change color
        Debug_SetColorByType(type);
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

        

    }

    void SetHealth(int healthValue)
    {
        health = healthValue;
    }

    void SetType(EnemyType typeToSet)
    {
        type = typeToSet;
    }

    void SetRandomType()
    {
        int randomNumber = UnityEngine.Random.Range(1, Enum.GetNames(typeof(EnemyType)).Length);
        type = (EnemyType)randomNumber;
    }

    void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    void SetRandomMoveSpeed(float minSpeed, float maxSpeed)
    {
        moveSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    void MoveEnemy()
    {
        transform.Translate(new Vector3(0f, -moveSpeed * Time.deltaTime, 0f));
    }

    public void SetEmptyVariables_SafetyCheck()
    {
        if(type == EnemyType.None) SetRandomType();

        if(moveSpeed == 0f) SetRandomMoveSpeed(minSpeed, maxSpeed);

        if (health == 0) SetHealth(1);
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

    private void Debug_SetColorByType(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Red:
                transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
                break;
            case EnemyType.Green:
                transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
                break;
            case EnemyType.Blue:
                transform.GetChild(0).GetComponent<Renderer>().material.color = Color.blue;
                break;
            case EnemyType.Yellow:
                transform.GetChild(0).GetComponent<Renderer>().material.color = Color.yellow;
                break;
        }
    }
    
}
