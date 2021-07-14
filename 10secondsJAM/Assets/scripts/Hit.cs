using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to manage the clicks on screen and kill enemies
public class Hit : MonoBehaviour
{
    Vector2 hitPosition;
    Camera cam;
    private LayerMask enemyLayerMask;
    float hitDamage = 10f;

    [SerializeField] private EnemiesManager enemiesManager;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        enemyLayerMask = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            hitPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Ray ray = cam.ScreenPointToRay(hitPosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, enemyLayerMask))
            {
                Enemy enemy = raycastHit.transform.GetComponent<Enemy>();
                bool enemyKilled = enemy.GetHit(hitDamage);
                if (enemyKilled)
                {
                    enemiesManager.KillOneEnemy(enemy);
                }
            }
        }
    }
}
