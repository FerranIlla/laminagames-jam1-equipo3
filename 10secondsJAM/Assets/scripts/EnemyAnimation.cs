using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Transform rotationCenter;
    private Vector3 rotationAxis;
    private float currentAngle = 0f;
    private float angleOffset = 0f;

    [SerializeField] private float oscillationSpeed = 1f;
    [Range(0,90)][SerializeField]
    private float maxAngle = 15f;

    // Start is called before the first frame update
    void Start()
    {
        rotationAxis = Vector3.back; //z world axis I think
        angleOffset = Random.Range(0, 360) * Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
    }


    void Animation()
    {
        //set to desired rotation
        float desiredAngle = CalculateDesiredRotationValueByTime(Time.time, maxAngle, oscillationSpeed);
        transform.RotateAround(rotationCenter.position, rotationAxis, desiredAngle-currentAngle);
        currentAngle = desiredAngle;
        
    }

    float CalculateDesiredRotationValueByTime(float time, float maxAngle, float speed)
    {
        float rotationValue;

        // sinuous value from time
        float t = Mathf.Sin(time*speed+ angleOffset);

        //remap sinuous value to angle value
        rotationValue = t * maxAngle;
        
        return rotationValue;
    }
}
