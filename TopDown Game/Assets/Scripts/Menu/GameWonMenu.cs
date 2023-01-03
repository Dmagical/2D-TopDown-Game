using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonMenu : MonoBehaviour
{
   
    


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        KillCounter.kills = 0;
        Cursor.visible = false;
        SceneManager.LoadScene("Game");
        AudioManager.manager.Play("Menu Confirm");
    }

    public void GoToMainMenu()
    {
        KillCounter.kills = 0;
        Cursor.visible = true;
        SceneManager.LoadScene("Main Menu");
        AudioManager.manager.Play("Menu Confirm");
    }

    public void QuitGame()
    {
        Application.Quit();
        AudioManager.manager.Play("Menu Back");
    }
}
