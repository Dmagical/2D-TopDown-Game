using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject GOMenu;
    public GameObject player;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        GOMenu.SetActive(false);
    }

    void Update()
    {
        if (PlayerHealth.playerHealth.GetHealth() == 0 && gameOver == false)
        {
            GOMenu.SetActive(true);
            Cursor.visible = true;
            gameOver = true;

        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        KillCounter.kills = 0;
        SceneManager.LoadScene("Main Menu");
        AudioManager.manager.Play("Menu Confirm");
        gameOver = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        AudioManager.manager.Play("Menu Back");
    }
}
