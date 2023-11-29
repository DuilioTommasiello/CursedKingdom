using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healpotion : MonoBehaviour
{
    public float PotionHeal = 20;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3 && other != null)
        {
            Destroy(gameObject);
        }
    }
}
