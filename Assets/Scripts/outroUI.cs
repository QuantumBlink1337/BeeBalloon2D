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
        var currentLevel = BeeBalloon.Instance.Level;
        if (currentLevel < BeeBalloon.Instance.Scenes.Count - 1)
        {
            endGameText.text = "GAME OVER! Defeated at Level " + currentLevel ;
        }
        else
        {
            endGameText.text = "You won!";
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
