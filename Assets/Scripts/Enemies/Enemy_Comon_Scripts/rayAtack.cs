using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayAtack : MonoBehaviour
{
    public int RayDmg = 10;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        movement player = collision.gameObject.GetComponent<movement>();
        if (collision.gameObject.layer == 3)
        {
                player.getDmg(RayDmg);
                Destroy(gameObject);         
        }
        
    }
}
