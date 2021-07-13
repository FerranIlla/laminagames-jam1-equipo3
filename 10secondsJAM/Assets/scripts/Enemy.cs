using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { None, Green, Blue, Yellow, Red}

public class Enemy : MonoBehaviour
{

    EnemyType type = EnemyType.None;
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float minSpeed = 0.5f;
    [SerializeField] private float maxSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        SetEmptyVariables_SafetyCheck();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

        

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
        if(type == EnemyType.None)
        {
            SetRandomType();
        }

        if(moveSpeed == 0f)
        {
            SetRandomMoveSpeed(minSpeed, maxSpeed);
        }
    }

    public void PrintEnemyData()
    {
        Debug.Log("Enemy of type " + type.ToString());
        Debug.Log("Enemy falling speed: " + moveSpeed);
    }

    void ReachFloor()
    {
        //destroy object
        //trigger animation
        //do damage
        //sound
        //etc
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            ReachFloor();
        }
    }
}
