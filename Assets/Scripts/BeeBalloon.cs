using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeBalloon : MonoBehaviour
{
    [SerializeField]
    private int defaultLives = 3;
    
    private int score = 0;

    private int lives = 0;

    private int level = 1;
    private int _startingLevel = 1;
    private int _losingLevel;
    
    private bool wonGame = false;

    public bool WonGame => wonGame;
    public int LosingLevel => _losingLevel;
    

    private float timeleft = 0;

    public float defaultTime = 30f;
    
    public static bool _isPaused = false;
    
    private List<String> _scenes = new() {"Level1", "Level2", "Level3"};

    private Camera _camera;
    
    private static BeeBalloon _instance;
    
    public static BeeBalloon Instance
    {
        get
        {
            if (_instance) return _instance;
            _instance = FindObjectOfType<BeeBalloon>();
            if (_instance) return _instance;
            GameObject go = new GameObject("BeeBalloon");
            _instance = go.AddComponent<BeeBalloon>();
            DontDestroyOnLoad(go);  // Keep the Singleton alive between scenes
            return _instance;
        }
    }

    public List<String> Scenes => _scenes;

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

    public int Level
    {
        get => level;
        set
        {
            level = value;
        }
    }

    public int StartingLevel
    {
        get => _startingLevel;
    }

    public int TimeLeft
    {
        get => (int)timeleft;
    }

    public void GameOver(bool won)
    {
        if (SceneManager.GetActiveScene().name == "Outro")
            return; // Avoid reloading Outro scene
        wonGame = won; 
        PlayerPrefs.SetInt("level", 0);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("lives", defaultLives);
        lives = defaultLives;
        _losingLevel = level;
        SceneManager.LoadScene("Outro");
    }
    public void PrepareGame()
    {
        _camera.orthographicSize = 23f;
        SceneManager.LoadScene(_scenes[_startingLevel-1]);
    }

    public void RestartGame()
    {
        _camera.orthographicSize = 5f;
        SceneManager.LoadScene("Intro");

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
        timeleft = defaultTime;
        level = 1;
        _camera = Camera.main;
        DontDestroyOnLoad(_camera);

        /*
         * If the player previously played, retrieve the current level. If it's within an acceptable range,
         * load it as a property.
         */
        if (PlayerPrefs.HasKey("level"))
        {
            int prefsLevel = PlayerPrefs.GetInt("level");
            if (prefsLevel <= _scenes.Count && prefsLevel > 0)
            {
                _startingLevel = prefsLevel;
                Level = prefsLevel; 
            }
        }
        Debug.Log("Starting Level: " + _startingLevel);

        /*
         * If the player previously played, retrieve their previous score. 
         */

        if (PlayerPrefs.HasKey("score"))
        {
            int prefsScore = PlayerPrefs.GetInt("score");
            if (prefsScore != 0)
            {
                score = prefsScore;
            }
        }
        Debug.Log("Starting Score: " + score);


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isPaused = !_isPaused;
            Time.timeScale = _isPaused ? 0 : 1;
        }
        if (BeeBalloon.Instance != null)
        {
            BeeBalloon.Instance.timeleft -= Time.deltaTime; // Reduce time by elapsed frame time
            if (BeeBalloon.Instance.timeleft < 0)
            {
                GameOver(false);
            }

            if (lives <= 0)
            {
                GameOver(false);
            }
        }
    }

    public  void CheckIfAllBalloonsPopped()
    {
        var allBalloons = FindObjectsOfType<Balloon>();
        if (allBalloons.Length <= 1)
        {
            if (level > (_scenes.Count - 1))
            {
                Debug.Log("All levels completed");
                GameOver(true);
                return;
            }
            level++;
            PlayerPrefs.SetInt("level", level);
            //add leftover time as points!
            score += TimeLeft * 10;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.Save();
            SceneManager.LoadScene(_scenes[level-1]);
        }

        
    }
}
