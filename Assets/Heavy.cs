using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : MonoBehaviour
{
    public float velocidad = 2f;
    public float distanciaAtaque = 1.5f; 
    public int danoAtaque = 20;
    public float tiempoStun = 2f;
    public movement playerMov;

    private Transform Ferana;
    private bool estaStuneado = false;

    void Start()
    {
        Ferana = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!estaStuneado)
        {
            if (Vector2.Distance(transform.position, Ferana.position) > distanciaAtaque)
            {
                Vector2 direccion = (Ferana.position - transform.position).normalized;
                transform.Translate(direccion * velocidad * Time.deltaTime);
            }
            else
            {
                Atacar();
            }
        }
    }

    void Atacar()
    {
   
        Ferana.GetComponent<movement>().getDmg(danoAtaque);
        
        Stunear();
    }

    void Stunear()
    {
        if (!estaStuneado)
        {
            estaStuneado = true;
            playerMov.enabled = false;
            Invoke("Desstunear", tiempoStun);
            playerMov.enabled = true;
        }
    }

    void Desstunear()
    {
        estaStuneado = false;
    }
}
