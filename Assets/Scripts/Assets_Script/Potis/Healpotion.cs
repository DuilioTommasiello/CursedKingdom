using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healpotion : MonoBehaviour
{
    public float playerlife;
    private movement playerMov;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Tocaste la poción");
        if (collision.gameObject.layer == 3)
        {
            var player = collision.gameObject.GetComponent<movement>();
            if (player != null)
            {
                if (player._life < 150 && player._life > 0)
                {
                    player._life += 50;
                }
                else
                {
                    player._life = 200;
                }

                var barLifeModifier = FindObjectOfType<BarlifeModifer>(); // Encuentra el objeto con el script BarlifeModifer
                if (barLifeModifier != null)
                {
                    barLifeModifier.changeActulLife(player._life); // Actualiza la barra de vida con el nuevo valor de vida del jugador
                }

                Destroy(gameObject); // Destruye la poción después de interactuar con ella
            }
        }
    }
}

