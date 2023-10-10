using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackTimers : MonoBehaviour
{
    public float _lifeTime = 0.2f;
    public int damageDealt = 10;

    public void Update()
    {
        Destroy(gameObject, _lifeTime);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("you hit something");

        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<EnemyLife>().GetDamage(damageDealt);
            Destroy(gameObject);
        }
        //if(collision.gameObject.layer == 9)
        //{
        //    collision.gameObject.GetComponent<_boxHealt>.GetDamage(damageDealt);
        //}
    }

 
}
