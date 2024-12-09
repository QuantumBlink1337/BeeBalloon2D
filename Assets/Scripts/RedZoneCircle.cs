using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZoneCircle : MonoBehaviour
{
    
    public float minRadius;
    public float maxRadius;

    public GameObject circleZone;

    public float oscillationSpeed = 2f;
    
    private float _currentRadius;

    private void FixedUpdate()
    {
       float t = Mathf.PingPong(Time.time * oscillationSpeed, 1f);
       _currentRadius = Mathf.Lerp(minRadius, maxRadius, t);
       circleZone.transform.localScale = new Vector3(_currentRadius * 2, _currentRadius * 2, 1f);
    }
}
