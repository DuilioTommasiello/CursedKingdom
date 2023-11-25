using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public int fogDmg = 50;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        { 
        movement player = collision.gameObject.GetComponent<movement>();
        player.getDmg(fogDmg);
        }


    }
}
