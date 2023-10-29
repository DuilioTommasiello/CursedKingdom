using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructable_door : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("slash"))
        {
            Destroy(gameObject);
        }
    }
}
