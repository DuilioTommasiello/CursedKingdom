using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] public movement mov;
    [SerializeField] public Habilities hab;

    [Header("values")]
    private float activeMoveSpeed;
    public float dashSpeed;

    private float dashLength = .5f, dashCoolDown = 1f;

    private float dashCounter;
    private float dashCoolCounter;


    void Start()
    {
        activeMoveSpeed = mov._movSpeed;
    }

    void Update()
    {
        Debug.Log("timer 1:" + dashCounter);
        Debug.Log("timer 2:" + dashCoolCounter);
        mov._PlayerRb.velocity = mov._moveInput * activeMoveSpeed;
       
        if (Input.GetKey(hab._EPower))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }
        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if(dashCounter <= 0)
            {
                activeMoveSpeed = mov._movSpeed;
                dashCoolCounter = dashCoolDown;
            }
        }
        if (dashCoolCounter > 0)
        {
        dashCoolCounter -= Time.deltaTime;
        }

    }
    private void dash()
    {

    }
}
