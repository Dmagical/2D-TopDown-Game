using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    private bool gameWon = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KillCounter.GetKills() == 30 && gameWon == false)
        {
            SceneManager.LoadScene("Game Won");
            gameWon = true;
            Cursor.visible = true;

        }
    }
}
