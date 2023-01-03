using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Cursor.visible = false;
        AudioManager.manager.Play("Menu Confirm");
    }

    public void QuitGame()
    {
        Application.Quit();
        AudioManager.manager.Play("Menu Back");
    }
}
