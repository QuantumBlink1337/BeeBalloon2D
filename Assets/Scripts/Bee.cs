using System.Collections;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public float moveSpeed = 5f; 
    
    
    private Camera _camera;
    private Rigidbody2D _rigidbody;

    public Vector2 startingPosition;
    private RespawnManager _respawnManager;


    
    void Start()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
        _respawnManager = FindObjectOfType<RespawnManager>();

        if (_camera == null)
        {
            Debug.LogError("No camera attached");
        }

        if (_respawnManager == null)
        {
            Debug.LogError("No respawn manager in scene");
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IObstacle>() != null)
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
            Debug.Log("Collision is a balloon");
        }
    }
}
