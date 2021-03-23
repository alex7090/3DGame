using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    Animator animator;

    public GameObject player;
    public float targetDistance;
    public float allowedRange;
    public float sprintRange;

    //public GameObject enemy;
    public float enemySpeed;
    public float sprintSpeed;
    public int attackTrigger;
    public RaycastHit shot;

    public GameObject projectile;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void kill()
    {
        sprintSpeed = 0;
        enemySpeed = 0;
        animator.SetBool("Alive", false);
        animator.SetBool("Run", false);
        animator.SetBool("Walk", false);

    }

    void Update()
    {
        transform.LookAt(player.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            if (targetDistance < allowedRange)
            {
                if (attackTrigger == 0)
                {
                    if (targetDistance < sprintRange)
                    {
                        animator.SetBool("Walk", false);
                        animator.SetBool("Run", true);
                        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, sprintSpeed);
                    } else if (targetDistance < allowedRange)
                    {
                        animator.SetBool("Run", false);
                        animator.SetBool("Walk", true);
                        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed);
                    } else
                    {
                        animator.SetBool("Run", false);
                        animator.SetBool("Walk", false);
                    }
                }
            }
            else
            {
                enemySpeed = 0.0f;

            }
        }
        //if (attackTrigger == 1)
        //{
        //    enemySpeed = 0;
        //    Instantiate(projectile, transform.position, Quaternion.identity);
        //}
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
