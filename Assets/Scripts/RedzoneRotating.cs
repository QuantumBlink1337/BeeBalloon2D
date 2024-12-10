using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedzoneRotating : MonoBehaviour
{
    public float rotationalSpeed = 20f;
    public float moveSpeed = 1f;

    private Transform[] redzones;

    private void Awake()
    {
        redzones = GetComponentsInChildren<Transform>();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationalSpeed * Time.fixedDeltaTime);
        foreach (Transform redzone in redzones)
        {
            redzone.Rotate(0f, 0f, rotationalSpeed*2 * Time.fixedDeltaTime);
        }
    }
    
}
