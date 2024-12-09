using System;
using System.Collections;
using UnityEditor.Build;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public float moveSpeed = 5f; 
    
    
    private Camera _camera;
    private Rigidbody2D _rigidbody;

    public Vector2 startingPosition;
    private RespawnManager _respawnManager;

    private bool _isVulnerable = false;
    private float _invulnerabilityTime = 4f;
    private float _invulnerabilityTimer = 0f;
    private SpriteRenderer[] _spriteRenderers; 


    void Start()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
        _respawnManager = FindObjectOfType<RespawnManager>();
       _spriteRenderers = GetComponentsInChildren<SpriteRenderer>(true);

        if (_camera == null)
        {
            Debug.LogError("No camera attached");
        }

        if (_respawnManager == null)
        {
            Debug.LogError("No respawn manager in scene");
        }
        if (_spriteRenderers.Length == 0)
        {
            Debug.LogError("No SpriteRenderer found in the child objects.");
        }
        else
        {
            foreach (var renderer in _spriteRenderers)
            {
                Debug.Log("Found SpriteRenderer on: " + renderer.gameObject.name);
            }
        }
    }

    void PerformDelayedMovement()
    {
        Vector2 targetLocation = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currentLocation = _rigidbody.position;
        
        // Debug.Log("Current Location: " + currentLocation);
        // Debug.Log("Target Location: " + targetLocation);
        
        Vector2 newPosition = Vector2.MoveTowards(currentLocation, targetLocation, Time.fixedDeltaTime * moveSpeed);
        
        _rigidbody.MovePosition(newPosition);

    }

    void FixedUpdate()
    {
        PerformDelayedMovement();
        
    }

    private void Update()
    {
        if (_isVulnerable)
        {
            _invulnerabilityTimer -= Time.fixedDeltaTime;
            if (_invulnerabilityTimer <= 0)
            {
                _isVulnerable = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IObstacle>() != null && !_isVulnerable)
        {
            Debug.Log("Collision is an obstacle");
            BeeBalloon.Lives--;
            Debug.Log("Lives: " + BeeBalloon.Lives);
            if (collision.gameObject.GetComponent<IObstacle>().Removable)
            {
                Destroy(collision.gameObject);
            }
            gameObject.transform.position = startingPosition;

            _respawnManager.RespawnBee(startingPosition);
            gameObject.SetActive(false);


        }
        else if (collision.gameObject.GetComponent<Balloon>() != null)
        {
            Debug.Log("Collision is an Balloon");
            Destroy(collision.gameObject);
            BeeBalloon.Score++;
            BeeBalloon.CheckIfAllBalloonsPopped();

        }
    }

    public void MakeInvulnerable()
    {
        _isVulnerable = true;
        _invulnerabilityTimer = _invulnerabilityTime;

        StartCoroutine(FlickerEffect());
    }
    
    private IEnumerator FlickerEffect()
    {
        if (_spriteRenderers == null || _spriteRenderers.Length == 0)
        {
            yield return null;  // Wait for one frame to ensure everything is set up
            _spriteRenderers = GetComponentsInChildren<SpriteRenderer>(true);  // Re-fetch just in case
        }
        bool isVisible = true; 
        while (_isVulnerable)
        {
            SetChildrenVisible(isVisible);// Toggle visibility
            isVisible = !isVisible;
            yield return new WaitForSeconds(1f); // Adjust flicker speed (0.1f for 10 flickers per second)
        }
        SetChildrenVisible(true);
    }

    private void SetChildrenVisible(bool visible)
    {
        foreach (var child in _spriteRenderers)
        {
            child.enabled = visible;
        }
    }
}
