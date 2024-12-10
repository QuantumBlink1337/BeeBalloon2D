using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class introUI : MonoBehaviour
{
    private string levelname;
    public Text startButtonText;
    public bool resetPrefs = false;

    void Start()
    {
        if (resetPrefs)
        {
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("level"))
        {
            int prefsLevel = PlayerPrefs.GetInt("level");
            if (prefsLevel > 1)
            {
                levelname = "Level"+prefsLevel;
                startButtonText.text = "Resume Level "+prefsLevel;
                return;
            }
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.Save();
        }
        levelname = "Level1";
        startButtonText.text = "Start";
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(levelname);
    }
}
