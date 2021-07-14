using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to manage the clicks on screen and kill enemies
public class Hit : MonoBehaviour
{
    Vector2 hitPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Click!");
            hitPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }
}
