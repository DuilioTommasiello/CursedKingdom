using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    public string targetTag; // El tag del objeto con el que queremos detectar colisiones
    public GameObject puertaCerrada; // El objeto cuyo SpriteRenderer queremos desactivar
    public GameObject puertaAbierta;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba si el objeto que ha colisionado tiene el tag deseado
        if (other.gameObject.CompareTag(targetTag))
        {
            // Intenta obtener el componente SpriteRenderer del objeto a desactivar
            SpriteRenderer PuertaCerrada = puertaCerrada.GetComponent<SpriteRenderer>();
            SpriteRenderer PuertaAbierta = puertaAbierta.GetComponent<SpriteRenderer>();
            Collider2D PuertaC = puertaCerrada.GetComponent<Collider2D>();
            // Si se encuentra el componente, lo desactiva
            if (PuertaCerrada != null)
            {
                PuertaCerrada.enabled = false;
                PuertaC.enabled = false;
                PuertaAbierta.enabled = true;
            }
        }
    }
}
