using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CursorVisibility : MonoBehaviour
{
    public Text text;
    public Button reload;

    void Start()
    {
        text.text = PlayerPrefs.GetString("reason", "Game Ended");
        Button btn = reload.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Game");
    }
    void OnLevelWasLoaded(int level)
    {
        if (FindObjectOfType<FirstPersonController>() != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}