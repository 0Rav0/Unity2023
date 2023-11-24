using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI Points;
    public TextMeshProUGUI Highscore;

    void Start()
    {
        Highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
        Points.text = PlayerPrefs.GetInt("Points").ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
