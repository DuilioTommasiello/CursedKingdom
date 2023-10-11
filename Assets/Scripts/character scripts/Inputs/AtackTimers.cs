using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackTimers : MonoBehaviour
{
    Object_Box_Searcher box;
    public float _lifeTime = 0.2f;
     public int damageDealt = 10;

    public void Awake()
    {
        
    }
    public void Update()
    {
        Destroy(gameObject, _lifeTime);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyLife enemy = collision.gameObject.GetComponent<EnemyLife>();
        Object_Box_Searcher box = collision.gameObject.GetComponent<Object_Box_Searcher>();
        Debug.Log("something has been hit");

        if (collision.gameObject.layer == 6 && enemy != null)
        {
            Debug.Log("enemy has been hit ");
                enemy.recibeDMG(damageDealt);
                Destroy(gameObject);
        }
        if (collision.gameObject.layer == 9 )
        {

            boxDMG();
            
        }
    }

    public void enemyDMG() 
    {
    }
    public void boxDMG() 
    {
        Debug.Log("box has been hit ");

        box._boxHealt -= damageDealt;
        if (box._boxHealt <= 0)
        {
            Destroy(gameObject);
        }
    }

 
}
