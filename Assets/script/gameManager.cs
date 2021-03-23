using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gun;

    private int zombies = 0;
    private int zombiesTarget = 10;
    private int saved = 0;
    private int savedTarget = 5;
    private int outlaw = 0;
    private int outlawTarget = 2;

    public Text obj1;
    public Text obj2;
    public Text obj3;


    public Text endText;
    public RectTransform endPanel;
    public RectTransform endColor;


    public Text timerText;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
    }

    public void zombieKill()
    {
        Debug.Log("KILLED ZOMBIE");
        zombies++;
    }
    public void outlawKill()
    {
        outlaw++;
    }
    public void savedOne()
    {
        saved++;
    }

    public void win()
    {
        PlayerPrefs.SetString("reason", "You Won");
        SceneManager.LoadScene("Win");
    }
    public void gameOver(int reason)
    {
        if (reason == 0)
        {
            PlayerPrefs.SetString("reason", "Game Over: you killed an innocent citizen");
            SceneManager.LoadScene("GameOver");
        }
        else if (reason == 1)
        {
            PlayerPrefs.SetString("reason", "Game Over: you got mugged by an outlaw");
            SceneManager.LoadScene("GameOver");

        }
        else if (reason == 2)
        {
            PlayerPrefs.SetString("reason", "Game Over: you got yourself killed by a zombie");
            SceneManager.LoadScene("GameOver");

        }
    }

    bool done()
    {
        if (outlaw >= outlawTarget && zombies >= zombiesTarget && saved >= savedTarget)
        {
            return true;
        } else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (zombies >= zombiesTarget)
        {
            obj1.color = Color.yellow;
            //CODE
        }
        if (outlaw >= outlawTarget)
        {
            obj2.color = Color.yellow;
            //CODE
        }
        if (saved >= savedTarget)
        {
            obj3.color = Color.yellow;
            //CODE
        }
        if (done())
        {
            win();
        }
        float t = Time.time - time;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f1");

        obj1.text = "Zombies Killed :    " + zombies + " / " + zombiesTarget;
        obj2.text = "Outlaws Killed:      " + outlaw + " / " + outlawTarget;
        obj3.text = "Innocents Saved:   " + saved + " / " + savedTarget;
        timerText.text = minutes + ";" + seconds;
    }
}
