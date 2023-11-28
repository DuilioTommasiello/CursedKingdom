using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMarkus : MonoBehaviour
{
    public Transform pointA; // Assign point A in the Unity editor
    public Transform pointB; // Assign point B in the Unity editor
    public float interactionDistance = 2f; // Adjust the interaction distance in the Unity editor

    public GameObject player;
    private bool isTransporting = false;
    private bool isMovingToB = true; // Start by moving to point B

    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && !isTransporting && IsPlayerClose())
        {
            StartTransport();
        }
    }

    void StartTransport()
    {
        isTransporting = true;

        // Set the player's position to the target position
        player.transform.position = isMovingToB ? pointB.position : pointA.position;

        // Switch the direction for the next transport
        isMovingToB = !isMovingToB;

        // Reset the script after the second transport
        if (!isMovingToB)
        {
            ResetScript();
        }

        isTransporting = false;
    }

    void ResetScript()
    {
        // Reset any script-specific variables or states here
        Debug.Log("Script Reset");

        // Example: You might reset other script-specific variables or states here
    }

    bool IsPlayerClose()
    {
        // Check if the player is close to the object based on the interactionDistance
        return Vector2.Distance(transform.position, player.transform.position) <= interactionDistance;
    }
}
