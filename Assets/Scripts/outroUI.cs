using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class outroUI : MonoBehaviour
{
    private string levelname;
    public Text endGameText;
    public InputField inputText;

    void Start()
    {
        endGameText.text = "GAME OVER!";
        if (PlayerPrefs.HasKey("level"))
        {
            int prefsLevel = PlayerPrefs.GetInt("level");
            endGameText.text = "GAME OVER on level: " + prefsLevel;
        }
        if (PlayerPrefs.HasKey("feedback"))
        {
            string prefsFeedback = PlayerPrefs.GetString("feedback");
            inputText.text = prefsFeedback;
        }
    }

    public void Submit()
    {
        PlayerPrefs.SetString("feedback", inputText.text);
        PlayerPrefs.Save();
    }
}
