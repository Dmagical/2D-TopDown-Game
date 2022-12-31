using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public static int kills;


    void Update()
    {
        ShowKills();
    }
    public void AddKill()
    {
        kills++;
    }

    private void ShowKills()
    {
        counterText.text = kills.ToString();
    }
}
