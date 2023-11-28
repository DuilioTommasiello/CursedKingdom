using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : MonoBehaviour
{
    public float velocidad = 1.5f;
    public float distanciaAtaque = 1f; 
    public int danoAtaque = 50;
    public float tiempoStun = 1f;
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
                transform.Translate(Time.deltaTime * velocidad * direccion);
            }
            else
            {
                Debug.Log("ejecuto el ataque");
                Atacar();
            }
        }
    }

    void Atacar()
    {
   
        Ferana.GetComponent<movement>().getDmg(danoAtaque);

        StartCoroutine(Stunear());
    }

    IEnumerator Stunear()
    {
        if (!estaStuneado)
        {
            estaStuneado = true;

            playerMov.enabled = false;
 
            yield return new WaitForSeconds(tiempoStun);

            playerMov.enabled = true;
            
            Desstunear();
        }
    }
    void Desstunear()
    {
        playerMov.enabled = true;

        estaStuneado = false;
    }
}
