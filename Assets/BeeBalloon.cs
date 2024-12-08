using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BeeBalloon : MonoBehaviour
{
    
    public static int score = 0;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score++;
    }
    
}
