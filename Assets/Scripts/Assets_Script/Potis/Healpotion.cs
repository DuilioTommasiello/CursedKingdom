using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healpotion : MonoBehaviour
{
    public float playerlife;
    private movement playerMov;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("tocaste la poti");
        if(collision.gameObject.layer == 3 )
        {
             var b = collision.gameObject.GetComponent<movement>();
            if(b._life <= 180 && b._life > 0)
            {
            b._life += 50;
            Destroy(gameObject);
            }else
            {
            Debug.Log("no se puede");
            }
        }
        
    }

}

