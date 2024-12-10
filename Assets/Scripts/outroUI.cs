using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class outroUI : MonoBehaviour
{
    private string levelname;
    public Text endGameText;
    public InputField inputText;

    void Start()
    {
        if (!BeeBalloon.Instance.WonGame)
        {
            endGameText.text = "GAME OVER! Defeated at Level " + BeeBalloon.Instance.LosingLevel.ToString(); ;
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

    public void PlayAgain()
    {
        SceneManager.LoadScene("Intro");
    }
}
