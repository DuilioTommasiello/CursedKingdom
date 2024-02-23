using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{

    private GameObject player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movement movimiento = collision.GetComponent<movement>();
            if (movimiento != null)
            {
                movimiento.enabled = false;
                Invoke(nameof(ReactivarMovimiento), 2f);
            }
        }
       
    }
    void ReactivarMovimiento()
    {
        // Encuentra el jugador en la escena. Asumiendo que solo hay uno.
        movement movimiento = FindObjectOfType<movement>();

        if (movimiento != null)
        {
            movimiento.enabled = true; // Reactiva el script de movimiento
        }
    }

}
