using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healpotion : MonoBehaviour
{
    [SerializeField] movement movM;
    [SerializeField] movement movF;
    public GameObject Mark;
    public GameObject fera;
    public Transform target;
    public SwitchCharacter swCh;
    public float PotionHeal = 20;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3 && other != null)
        {
            
            if (movF._life < 200 && swCh.FeranaIsPLaying == true && target == fera)
            {
                Debug.Log("te heleaste");
                movF._life += PotionHeal;
                Destroy(gameObject);
            }
            else if (movM._life < 200 && swCh.FeranaIsPLaying == false && target == Mark)
            {
                
                Debug.Log("te heleaste");
                movM._life += PotionHeal;
                Destroy(gameObject);
            }

        }
    }
}
