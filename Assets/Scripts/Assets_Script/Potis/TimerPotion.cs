using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.layer == 3)
        {
        var p = collision.gameObject.GetComponent<Habilities>();
            p.basicReady = true;
            p.Zready= true;
            p.Xready= true;
            p.Cready= true;
            p._BasicCounter = 0;
            p._Zcounter = 0;
            p._Xcounter = 0;
            p._Ccounter = 0;
            Destroy(gameObject);
        }
    }
}
