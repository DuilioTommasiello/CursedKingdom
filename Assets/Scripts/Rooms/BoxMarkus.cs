using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMarkus : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB; 
    public float interactionDistance = 1f;

    public GameObject player;
    private bool isTransporting = false;
    private bool isMovingToB = true;

    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetButtonDown("Interaction") && !isTransporting && IsPlayerClose())
        {
            StartTransport();
        }
    }

    void StartTransport()
    {
        isTransporting = true;

        player.transform.position = isMovingToB ? pointB.position : pointA.position;

        isMovingToB = !isMovingToB;


        if (!isMovingToB)
        {
            ResetScript();
        }

        isTransporting = false;
    }

    void ResetScript()
    {
        Debug.Log("Script Reset");
    }

    bool IsPlayerClose()
    {
        return Vector2.Distance(transform.position, player.transform.position) <= interactionDistance;
    }

    
}
