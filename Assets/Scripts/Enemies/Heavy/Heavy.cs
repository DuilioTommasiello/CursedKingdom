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
    public float stuntimer;
    public float stuntime;
    public float AtackTimer;
    public float tiempoStun = 1f;
    public float cooldownEntreAtaques = 2f;

    [Header("character")]
    private movement playerMov;
    public GameObject Ferana;
    public GameObject Markus;
    private GameObject target;
    public SwitchCharacter swNum;

    

    void Update()
    {
        playerMov = GetComponent<movement>();
        if (swNum.FeranaIsPLaying == true)
        {
            target = Ferana;
        }
        else
        {
            target = Markus;
        }
        if (target != null)
        {
            distanciaAlObjetivo = Vector2.Distance(transform.position, target.transform.position);

            if (distanciaAlObjetivo > distanciaAtaque)
            {
                Vector2 direccion = (target.transform.position - transform.position).normalized;
                transform.Translate(Time.deltaTime * velocidad * direccion);
            }
            else
            {
                stuntime += Time.deltaTime;
                if (stuntime < 3)
                { 
                Stunear();
                }else if(stuntime > 4)
                {
                    stuntime = 0;
                }

                    Atacar();
            }
        }
    }

    void Atacar()
    {

            AtackTimer += Time.deltaTime;
            if(AtackTimer >= 2)
            {
            var L = target.GetComponent<movement>();
            L.getDmg(danoAtaque);
            AtackTimer = 0;
            }
        
    }

        private void  Stunear()
    {
        Debug.Log("stuneado puto");

            estaStuneado = true;
            var b = target.GetComponent<movement>();
            b.enabled = false;
            
            stuntimer += Time.deltaTime;
            if(stuntimer >= 1 && estaStuneado == true)
            {
            b.enabled = true;
            estaStuneado = false;
            //stuntimer = 0;
            }

           
    }
}



