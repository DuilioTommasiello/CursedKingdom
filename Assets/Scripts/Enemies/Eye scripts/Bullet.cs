using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    [SerializeField] public float speed;
    [SerializeField] public int _bulletdamage = 30;
    Rigidbody2D bulletRB;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");

        if (target != null && bulletRB != null)
        {
            Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
            bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
            Destroy(gameObject, 2);
        }
        else
        {
            Destroy(gameObject); // Destruye el objeto si no se puede encontrar al jugador o el Rigidbody2D es nulo
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            movement player = collision.gameObject.GetComponent<movement>();
            if (player != null)
            {
                player.getDmg(_bulletdamage);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9 || collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }
}