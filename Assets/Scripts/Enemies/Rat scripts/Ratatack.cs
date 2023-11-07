using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratatack : MonoBehaviour
{
    [SerializeField] CharacterChase chsp;
    private int Ratdmg = 10;
    private bool needToStop = false;
    private int index;
    private float timer;
    private void FixedUpdate()
    {
        if(needToStop == true)
        {
            chsp.speed = 0;
            chsp.chasedistance = 20;
            timer += Time.fixedDeltaTime;
        }
        if(timer >= 1)
        {
            needToStop = false;
            chsp.speed = 3;         
            timer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        movement player = collision.gameObject.GetComponent<movement>();
        if (collision.gameObject.layer == 3)
        {
            if(index == 0)
            {
            player.getDmg(Ratdmg);
            index++;
            needToStop = true;
            }
            if (index == 1 && needToStop == false)
            {
            player.getDmg(Ratdmg*2);
             Destroy(gameObject);
            }

        }
    }
}
