using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class introUI : MonoBehaviour
{
    private string levelname;
    public Text startButtonText;

    void Start()
    {
        startButtonText.text = "Start " + BeeBalloon.Instance.Scenes[BeeBalloon.Instance.StartingLevel-1];
    }

    public void LoadGame()
    {
        BeeBalloon.Instance.PrepareGame();
    }
}
