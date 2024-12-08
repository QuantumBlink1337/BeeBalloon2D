using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float minimumScale = 1f;
    public float maximumScale = 2f;
    
    public List<Material> materials = new List<Material>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        BeeBalloon.AddScore();
        Destroy(this.gameObject);
    }
}
