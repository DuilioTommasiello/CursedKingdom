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


    void Update()
    {
        if (swNum.FeranaIsPLaying == true )
        {
            chaseF();
            if (target != null && !estaStuneado)
            {
                if (distanciaAlObjetivo > distanciaAtaque)
                {
                    Vector2 direccion = (target.position - transform.position).normalized;
                    transform.Translate(Time.deltaTime * velocidad * direccion);
                }
            }
            else
            {
                if (Time.time - tiempoUltimoAtaque >= cooldownEntreAtaques)
                {
                    Debug.Log("Ejecuto el ataque");
                    Atacar();
                    tiempoUltimoAtaque = Time.time;
                }
            }
        }
        else
        {
            chaseM();
            if (target != null && !estaStuneado)
            {
                if (distanciaAlObjetivo > distanciaAtaque)
                {
                    Vector2 direccion = (target.position - transform.position).normalized;
                    transform.Translate(Time.deltaTime * velocidad * direccion);
                }
                else
                {
                    if (Time.time - tiempoUltimoAtaque >= cooldownEntreAtaques)
                    {
                        Debug.Log("Ejecuto el ataque");
                        Atacar();
                        tiempoUltimoAtaque = Time.time;
                    }
                }
            }
        }
        
    }
    
    void chaseF()
    {
        int layerMask = LayerMask.GetMask("walls");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Ferana.transform.position, 1f, layerMask);
        distanciaAlObjetivo = Vector2.Distance(transform.position, Ferana.transform.position);
        if (distanciaAlObjetivo <= chaseDistance && hit.collider == null)
        {
            Vector2 direction = Ferana.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.position = Vector2.MoveTowards(this.transform.position, Ferana.transform.position, velocidad * Time.deltaTime);
        }
    }
    void chaseM()
    {
        int layerMask1 = LayerMask.GetMask("walls");
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position, Markus.transform.position, 1f, layerMask1);
        distanciaAlObjetivo = Vector2.Distance(transform.position, Markus.transform.position);
        if (distanciaAlObjetivo <= chaseDistance && hit1.collider == null)
        {
            Vector2 direction = Markus.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.position = Vector2.MoveTowards(this.transform.position, Markus.transform.position, velocidad * Time.deltaTime);
        }
    }
    

    void Atacar()
    {
        if (target != null)
        {
            playerMov.getDmg(danoAtaque);
            StartCoroutine(Stunear());
        }
    }

    IEnumerator Stunear()
    {
        if (!estaStuneado)
        {
            estaStuneado = true;
            playerMov.enabled = false;
            yield return new WaitForSeconds(tiempoStun);
            playerMov.enabled = true;
            estaStuneado = false;
        }
    }
}



