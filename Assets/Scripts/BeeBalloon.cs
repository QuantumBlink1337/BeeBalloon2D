using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BeeBalloon : MonoBehaviour
{
    [SerializeField]
    private int defaultLives = 3;
    
    private static int score = 0;

    private static int lives = 0;

    public static int Score
    {
        get => score;
        set => score = value;
    }

    public static int Lives
    {
        get => lives;
        set => lives = value;
    }

    private void Awake()
    {
        lives = defaultLives;
    }
}
