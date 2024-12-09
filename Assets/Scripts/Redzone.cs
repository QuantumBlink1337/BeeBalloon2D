using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redzone : MonoBehaviour, IObstacle
{
    private bool _removable;

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     Debug.Log(other.gameObject.name);
    // }
    private void Awake()
    {
        _removable = false;
    }

    bool IObstacle.Removable
    {
        get => _removable;
        set => _removable = value;
    }
}
