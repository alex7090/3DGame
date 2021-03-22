using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public GameObject player;
    public float targetDistance;
    public float allowedRange = 10;

    public GameObject enemy;
    public float enemySpeed;
    public int attackTrigger;
    public RaycastHit shot;

    public GameObject projectile;

    void Update()
    {
        transform.LookAt(player.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            if (targetDistance < allowedRange)
            {
                enemySpeed = 0.05f;
                if (attackTrigger == 0)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed);
                }
            }
            else
            {
                enemySpeed = 0.0f;

            }
        }
        if (attackTrigger == 1)
        {
            enemySpeed = 0;
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter()
    {
        attackTrigger = 1;
    }

    void OnTriggerExit()
    {
        attackTrigger = 0;
    }
}
