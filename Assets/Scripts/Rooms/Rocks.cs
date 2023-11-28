using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public Transform pointA; // Assign the point A in the Unity editor
    public Transform pointB; // Assign the point B in the Unity editor
    public float moveSpeed = 2f; // Adjust the movement speed in the Unity editor
    public float interactionDistance = 2f; // Adjust the interaction distance in the Unity editor

    public GameObject player;
    private bool isMoving = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && IsPlayerClose())
        {
            // Start moving when V key is pressed and the player is close
            StartMoving();
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            // Stop moving when V key is released
            StopMoving();
        }
    }

    void StartMoving()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveToB());
        }
    }

    void StopMoving()
    {
        isMoving = false;
    }

    IEnumerator MoveToB()
    {
        isMoving = true;

        float time = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = pointB.position;

        while (time < 1f)
        {
            time += Time.deltaTime / moveSpeed;
            transform.position = Vector3.Lerp(startPosition, targetPosition, time);

            // Check if movement should be interrupted
            if (!isMoving)
            {
                yield break; // Exit the coroutine
            }

            yield return null;
        }

        // Ensure that the object stops moving when the interpolation is complete
        isMoving = false;
    }

    bool IsPlayerClose()
    {
        // Check if the player is close to the object based on the interactionDistance
        return Vector2.Distance(transform.position, player.transform.position) <= interactionDistance;
    }
}
