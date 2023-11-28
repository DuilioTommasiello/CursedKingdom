using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiBox : MonoBehaviour
{
    public float radioExplosion = 5f;
    public float damage = 50;
    [SerializeField] GameObject ferana;
    [SerializeField] GameObject Markus;
    [SerializeField] SwitchCharacter swCh;

    private bool exploded = false;

    void Update()
    {
        if (ferana != null && Markus != null && swCh != null)
        {
            if (!exploded && (swCh.FeranaIsPLaying == true && Vector2.Distance(transform.position, ferana.transform.position) < 2f))
            {
                Debug.Log("debug explode fer");
                Explode();
            }
            if (!exploded && (swCh.FeranaIsPLaying == false && Vector2.Distance(transform.position, Markus.transform.position) < 2f))
            {
                Debug.Log("debug explode mar");
                Explode();
            }
        }

    }

    void Explode()
    {
        Debug.Log("algo");
        exploded = true;
        GetComponent<CircleCollider2D>().enabled = true;

        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radioExplosion);

        foreach (Collider2D hit in colliders)
        {
            if (hit.CompareTag("Enemies"))
            {
                Debug.Log("debug 1");
                hit.GetComponent<EnemyLife>().recibeDMG(damage);
            }
            if (hit.CompareTag("Player"))
            {
                Debug.Log("debug 2");
                hit.GetComponent<movement>().getDmg(damage);
            }
            if (hit.CompareTag("Attacks"))
            {
                Debug.Log("debug 3");
            }
            
        }
        Destroy(gameObject);

    }
        
 }

