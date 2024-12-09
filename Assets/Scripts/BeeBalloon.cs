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
    
    private int score = 0;

    private int lives = 0;
    
    private bool _isPaused = false;
    private List<String> _scenes = new List<String>{"Level1", "Level2" };
    private int currentScene = 0;
    
    private static BeeBalloon _instance;
    
    public static BeeBalloon Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<BeeBalloon>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("BeeBalloon");
                    _instance = go.AddComponent<BeeBalloon>();
                    DontDestroyOnLoad(go);  // Keep the Singleton alive between scenes
                }
            }
            return _instance;
        }
    }
    public  int Score
    {
        get => score;
        set
        {
            score = value;
        }
    }

    public  int Lives
    {
        get => lives;
        set
        {
            lives = value;
        } 
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);  // Ensures only one instance of BeeBalloon exists
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);  // Persist the object across scenes
        lives = defaultLives;  // Set the default lives
        score = 0; 
        
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isPaused = !_isPaused;
            Time.timeScale = _isPaused ? 0 : 1;
        }
    }

    public  void CheckIfAllBalloonsPopped()
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
