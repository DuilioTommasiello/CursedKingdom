using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayAtack : MonoBehaviour
{
    public float RayDmg = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            var player = collision.gameObject.GetComponent<movement>();
            if (player != null && collision.gameObject.layer == 3)
            {
                player.getDmg(RayDmg);
                Destroy(gameObject);
            }
        }
    }
}
