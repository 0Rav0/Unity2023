using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SummaryMenu : MonoBehaviour
{
    public TextMeshProUGUI Points;
    public TextMeshProUGUI Highscore;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI UpgradeLabel;
    public Button UpgradeButton;

    void Start()
    {
        Highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
        Score.text = PlayerPrefs.GetInt("Score").ToString();
        Points.text = PlayerPrefs.GetInt("Points").ToString();
        UpgradeLabel.text = "Ulepszenia " + PlayerPrefs.GetInt("Upgrades").ToString() + "/10";

        if (PlayerPrefs.GetInt("Points") >= 10 && PlayerPrefs.GetInt("Upgrades") < 10)
        {
            UpgradeButton.interactable = true;
        }
        else
            UpgradeButton.interactable = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerPrefs.SetInt("Highscore", 0);
            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetInt("Points", 0);
            PlayerPrefs.SetInt("Upgrades", 0);

            Highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
            Points.text = PlayerPrefs.GetInt("Points").ToString();
            UpgradeLabel.text = "Ulepszenia " + PlayerPrefs.GetInt("Upgrades").ToString() + "/10";
            UpgradeButton.interactable = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerPrefs.SetInt("Points", 100);
            Points.text = PlayerPrefs.GetInt("Points").ToString();

            if (PlayerPrefs.GetInt("Upgrades") < 10)
                UpgradeButton.interactable = true;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Upgrade()
    {
        PlayerPrefs.SetInt("Upgrades", PlayerPrefs.GetInt("Upgrades") + 1);
        int points = PlayerPrefs.GetInt("Points");
        points -= 10;
        PlayerPrefs.SetInt("Points", points);
        Points.text = PlayerPrefs.GetInt("Points").ToString();
        UpgradeLabel.text = "Ulepszenia " + PlayerPrefs.GetInt("Upgrades").ToString() + "/10";

        if (PlayerPrefs.GetInt("Points") < 10 || PlayerPrefs.GetInt("Upgrades") >= 10)
            UpgradeButton.interactable = false;
    }
}
