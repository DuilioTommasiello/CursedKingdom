using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratatack : MonoBehaviour
{
    private int Ratdmg = 10;
    private int index;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        movement player = collision.gameObject.GetComponent<movement>();
        if (collision.gameObject.layer == 3)
        {
            if(index == 0)
            {
            player.getDmg(Ratdmg);
            index++;
                Debug.Log("se ejecuto" + index);
            }
            else if (index == 2)
            {
            player.getDmg(Ratdmg*2);
             Destroy(gameObject);
                Debug.Log("se ejecuto" + index);
            }

        }
    }
}
