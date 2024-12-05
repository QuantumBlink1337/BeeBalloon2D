using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public GameObject zone;
    public GameObject pivotEnd;
    public GameObject pivotStart;
    private Rigidbody2D _pivotEndRB;
    private Rigidbody2D _pivotRB;
    public float rotationalSpeed = 20f;
    public float moveSpeed = 1f;

    private bool _moveToTarget = false;

    private Vector2 originalPosition; 
        
        


    void Start()
    {

            
    }
    
    // Start is called before the first frame update
    void FixedUpdate()
    {
        zone.transform.Rotate(0, 0, rotationalSpeed * Time.fixedDeltaTime);
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        if (_moveToTarget)
        {
            zone.transform.position = Vector3.MoveTowards(zone.transform.position, pivotEnd.transform.position, moveSpeed * Time.fixedDeltaTime);
            if (Vector3.Distance(zone.transform.position, pivotEnd.transform.position) < 0.1f)
            {
                _moveToTarget = false;
            }
        }
        else
        {
            zone.transform.position = Vector3.MoveTowards(zone.transform.position, pivotStart.transform.position, moveSpeed * Time.fixedDeltaTime);
            
            if (Vector3.Distance(zone.transform.position,  pivotStart.transform.position) < 0.1f)
            {
                _moveToTarget = true;
            }
        }
    }
}
