using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public float moveSpeed = 5f; 
    
    
    private Camera _camera;
    private Rigidbody2D _rigidbody;
    
    
    
    
    void Start()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();

        if (_camera == null)
        {
            Debug.LogError("No camera attached");
        }
    }

    void PerformDelayedMovement()
    {
        Vector2 targetLocation = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentLocation = _rigidbody.position;
        
        Debug.Log("Current Location: " + currentLocation);
        Debug.Log("Target Location: " + targetLocation);
        
        Vector2 newPosition = Vector2.MoveTowards(currentLocation, targetLocation, Time.fixedDeltaTime * moveSpeed);
        
        _rigidbody.MovePosition(newPosition);

    }

    void FixedUpdate()
    {
        PerformDelayedMovement();
        
    }
}
