using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimations : MonoBehaviour
{
    [Header("Animator")]
    public Animator playerAnimator;

    private movement mov;
    private Vector2 _moveInput;
    void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        
    }

    void Update()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        
        if(moveX != 0 || moveY != 0)
        {
            playerAnimator.SetFloat("Horizontal", moveX);
            playerAnimator.SetFloat("Vertical", moveY);
        }
      }

 

    
}
