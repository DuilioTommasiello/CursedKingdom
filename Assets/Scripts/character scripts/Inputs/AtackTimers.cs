using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackTimers : MonoBehaviour
{
    Object_Box_Searcher box;
    public float _lifeTime = 0.2f;
    public int damageDealt = 10;


    public void Update()
    {
        Destroy(gameObject, _lifeTime);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyLife enemy = collision.gameObject.GetComponent<EnemyLife>();
        BossLife boss = collision.gameObject.GetComponent<BossLife>();
        Object_Box_Searcher box = collision.gameObject.GetComponent<Object_Box_Searcher>();

        if (collision.gameObject.layer == 6 && enemy != null)
        {
            enemy.recibeDMG(damageDealt);

            Destroy(gameObject, 2f);

        }
        if (box != null && collision.gameObject.layer == 9)
        {
            box.boxDmg(damageDealt);
            Destroy(gameObject, 2f);
        }
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject, 2f);

        }
    }
    



}
