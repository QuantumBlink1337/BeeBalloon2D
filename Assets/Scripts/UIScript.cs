using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public Text levelText; // Assign via Inspector
    public Text scoreText; // Assign via Inspector
    public Text timeText;  // Assign via Inspector
    public Text livesText; // Assign via Inspector

    // Update is called once per frame
    void Update()
    {
        if (BeeBalloon.Instance != null)
        {
            // Update score and lives text
            scoreText.text = "Score: " + BeeBalloon.Instance.Score;
            livesText.text = "Lives: " + BeeBalloon.Instance.Lives;
            levelText.text = "Level: " + BeeBalloon.Instance.Level;
            timeText.text = "Time Left (secs): " + BeeBalloon.Instance.TimeLeft;
        }
    }
}
