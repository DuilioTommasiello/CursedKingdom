using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEyeFollow : MonoBehaviour
{
    [Header("Animator")]
    public SwitchCharacter swNum;
    public CharacterChase chase;
    public GameObject ferrana;
    public GameObject markus;
    public Animator EyeAnim;
    public float directionX;
    public float directionY;


    private void Awake()
    {
        EyeAnim = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {

        if (swNum.FeranaIsPLaying == true)
        {
             directionX = ferrana.transform.position.x - transform.position.x;
             directionY = ferrana.transform.position.y - transform.position.y;

        }
        else
        {
            directionX = markus.transform.position.x - transform.position.x;
            directionY = markus.transform.position.y - transform.position.y;

        }
        EyeAnim.SetFloat("enemyX", directionX);
        EyeAnim.SetFloat("enemyY", directionY);  
    }

}
