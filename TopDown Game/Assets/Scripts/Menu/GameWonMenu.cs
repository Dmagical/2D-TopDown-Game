using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonMenu : MonoBehaviour
{
    public GameObject winMenu;
    private bool GameWon = false;


    void Start()
    {
        winMenu.SetActive(false);
    }

    
    void Update()
    {
        if (KillCounter.kills == 5 && GameWon == false)
        {
            Time.timeScale = 0f;
            winMenu.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        KillCounter.kills = 0;
        SceneManager.LoadScene("Game");
        AudioManager.manager.Play("Menu Confirm");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        AudioManager.manager.Play("Menu Confirm");
    }

    public void QuitGame()
    {
        Application.Quit();
        AudioManager.manager.Play("Menu Back");
    }
}
