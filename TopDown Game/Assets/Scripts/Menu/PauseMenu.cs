using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;


    void Start()
    {
        pauseMenu.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
        isPaused = true;
        AudioManager.manager.Play("Menu Hover");
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1f;
        AudioManager.manager.Play("Menu Back");
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        Cursor.visible = true;
        KillCounter.kills = 0;
        SceneManager.LoadScene("Main Menu");
        AudioManager.manager.Play("Menu Confirm");
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        AudioManager.manager.Play("Menu Back");
    }
}
