using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IObstacle
{
    private bool _removable;

    void Start()
    {
        _removable = true;
    }
    bool IObstacle.Removable
    {
        get => _removable;
        set => _removable = value;
    }
}
