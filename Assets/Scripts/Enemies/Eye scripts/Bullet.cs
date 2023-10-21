using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject target;
    [SerializeField]public float speed;
    [SerializeField]public int _bulletdamage = 30;
    Rigidbody2D bulletRB;
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        movement player = collision.gameObject.GetComponent<movement>();

        if (collision.gameObject.layer == 3 )
        {
            player.getDmg(_bulletdamage);
        }

        Destroy(gameObject);
    }


}
