using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeBalloon : MonoBehaviour
{
    [SerializeField]
    private int defaultLives = 3;
    
    private static int score = 0;

    private static int lives = 0;
    
    private static bool _isPaused = false;
    private static List<String> _scenes = new List<String>{"Level1", "Level2" };
    private static int currentScene = 0;
    public static int Score
    {
        get => score;
        set
        {
            score = value;
            PlayerPrefs.SetInt("Score", score); // Save score to PlayerPrefs
        }
    }

    public static int Lives
    {
        get => lives;
        set
        {
            lives = value;
            PlayerPrefs.SetInt("Lives", lives); // Save lives to PlayerPrefs
        } 
    }

    private void Awake()
    {
        lives = defaultLives;
        
        score = PlayerPrefs.GetInt("Score", 0);
        lives = PlayerPrefs.GetInt("Lives", 3);
        
        Debug.Log($"Score: {score}, Lives: {lives}");
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isPaused = !_isPaused;
            Time.timeScale = _isPaused ? 0 : 1;
        }
    }

    public static void CheckIfAllBalloonsPopped()
    {
        var allBalloons = FindObjectsOfType<Balloon>();
        if (allBalloons.Length <= 1)
        {
            currentScene++;
            Debug.Log("All balloons popped");
            SceneManager.LoadScene(_scenes[currentScene]);
        }
        
    }
}
