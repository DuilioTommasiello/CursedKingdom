using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Markus : MonoBehaviour
{
    private movement mov;
    [SerializeField] private float dashVelocity;
    [SerializeField] private float dashTempo;
    private int initialGravity;
    private bool canDash = true;
    private bool canMove = true;

    private void Start()
    {
        
    }
}
