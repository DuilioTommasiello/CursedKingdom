using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiBox : MonoBehaviour
{

    public float radioExplosion = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hice algo");
            explode();
        }
    }

    void explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radioExplosion);

        foreach (Collider2D hit in colliders)
        {
            if (hit.CompareTag("Enemies"))
            {
                Debug.Log("explote");
                Destroy(hit.gameObject);
            }
        }
        Destroy(gameObject);
    }
}
