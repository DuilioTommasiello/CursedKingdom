using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : MonoBehaviour
{
    [Header("chase")]
    public float velocidad = 1.5f;
    public float distanciaAtaque = 1f;
    public float distanciaAlObjetivo;
    public float chaseDistance = 5f;
    private bool estaStuneado = false;
    private float tiempoUltimoAtaque;

    [Header("dmg")]
    public int danoAtaque = 50;
    public float tiempoStun = 1f;
    public float cooldownEntreAtaques = 2f;

    [Header("character")]
    private movement playerMov;
    public Transform Ferana;
    public Transform Markus;
    private Transform target;
    public SwitchCharacter swNum;

    void Start()
    {
        
        playerMov = GetComponent<movement>();
    }

    void Update()
    {
        if (swNum.FeranaIsPLaying == true)
        {
            target = Ferana;
        }
        else
        {
            target = Markus;
        }

        
        if (target != null && !estaStuneado)
        {
            distanciaAlObjetivo = Vector2.Distance(transform.position, target.position);

            if (distanciaAlObjetivo > distanciaAtaque)
            {
                Vector2 direccion = (target.position - transform.position).normalized;
                transform.Translate(Time.deltaTime * velocidad * direccion);
            }
            else
            {
                
                if (Time.time - tiempoUltimoAtaque >= cooldownEntreAtaques)
                {
                    Atacar();
                    tiempoUltimoAtaque = Time.time;
                }
            }
        }
    }

    void Atacar()
    {
        if (target != null && playerMov != null)
        {
            playerMov.getDmg(danoAtaque);
            StartCoroutine(Stunear());
            StartCoroutine(EsperarEntreAtaques());
        }
    }

    IEnumerator Stunear()
    {
        if (!estaStuneado && playerMov != null)
        {
            estaStuneado = true;
            playerMov.enabled = false;
            yield return new WaitForSeconds(tiempoStun);
            playerMov.enabled = true;
            estaStuneado = false;
        }
    }

    IEnumerator EsperarEntreAtaques()
    {
        yield return new WaitForSeconds(cooldownEntreAtaques);
    }
}



