using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimations : MonoBehaviour
{
    [Header("Animator")]
    public Animator playerAnimator;
    public bool isMoving;
    public bool isAtcking;

    private movement mov;
    private Habilities Hab;
    private Vector2 _moveInput;
    void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        float LastmoveX = Input.GetAxis("Horizontal");
        float LastmoveY = Input.GetAxis("Vertical");

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);

        

        if (moveX != 0 || moveY != 0)
        {
            playerAnimator.SetFloat("LastHor", LastmoveX);
            playerAnimator.SetFloat("LastVert", LastmoveY);
            playerAnimator.SetBool("isMoving", isMoving = true);
        }
        //if (Hab.basicAtack && isAtcking == true)
        //{
        //    Hab.basicAtacks();
        //    playerAnimator.SetBool("isAtcking", isAtcking = true);
        //}
        else
        {
            playerAnimator.SetBool("isMoving", isMoving = false);
            //playerAnimator.SetBool("isAtcking", isAtcking = false);
        }
      }

 

    
}
