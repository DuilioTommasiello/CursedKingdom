using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            // var atk = GetComponent<AtackTimers>();
            //atk.needToUpgrade = true;
            Destroy(gameObject);
        }

    }
}
