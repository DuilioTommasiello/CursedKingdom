using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visionAngle : MonoBehaviour
{
    public float rotationSpeed;
    public Camera cam;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector2 mousePointer = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePointer - (Vector2)transform.position;
        transform.up = Vector2.MoveTowards(transform.up, direction, rotationSpeed);
 
    }
}
