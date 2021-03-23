using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject manager;
    public GameObject zombienManager;
    private bool alive = true;
    public float health = 50f;

    public void saved()
    {
        if (gameObject.name == "citizen")
        {
            manager.transform.GetComponent<gameManager>().savedOne();
            die();
        }
        else if (gameObject.name == "outlaw")
        {
            manager.transform.GetComponent<gameManager>().gameOver(1);
        }
        else if (gameObject.name == "zombie" && alive)
        {
            manager.transform.GetComponent<gameManager>().gameOver(2);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            if (gameObject.name == "Z_Head")
            {
                alive = false;
                zombienManager.transform.GetComponent<EnemiesManager>().kill();
                manager.transform.GetComponent<gameManager>().zombieKill();
            }
            if (gameObject.name == "citizen")
            {
                manager.transform.GetComponent<gameManager>().gameOver(0);
            }
            if (gameObject.name == "outlaw")
            {
                manager.transform.GetComponent<gameManager>().outlawKill();
            }
            die();
        }
    }

    private void die()
    {
        Destroy(gameObject);
    }

}
