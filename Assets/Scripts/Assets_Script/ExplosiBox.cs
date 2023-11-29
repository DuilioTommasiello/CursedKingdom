using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiBox : MonoBehaviour
{
    public float radioExplosion = 5f;
    public int damage = 50;
    SwitchCharacter swCh;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && swCh.FeranaIsPLaying == true)
        {
            
            movement playerMovement = other.GetComponent<movement>();
            if (playerMovement != null)
            {
                playerMovement.getDmg(playerMovement._life / 2);
            }
            Explode();
        }
        else if (other.CompareTag("Player") && swCh.FeranaIsPLaying == false)
        {
            movement playerMovement = other.GetComponent<movement>();
            if (playerMovement != null)
            {
                playerMovement.getDmg(playerMovement._life / 2);
            }
            Explode();
        }
        else if (other.CompareTag("Enemies"))
        {
            
            Destroy(other.gameObject);
            Explode();
        }
        else if (other.CompareTag("Attacks"))
        {

            Explode();
        }
    }

    void Explode()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radioExplosion);

        foreach (Collider2D hit in colliders)
        {
            if (hit != null)
            {
                if (hit.CompareTag("Enemies"))
                {
                    EnemyLife enemyLife = hit.GetComponent<EnemyLife>();
                    if (enemyLife != null)
                    {
                        enemyLife.recibeDMG(damage);
                    }
                }
                else if (hit.CompareTag("Player"))
                {
                    movement playerMovement = hit.GetComponent<movement>();
                    if (playerMovement != null)
                    {
                        playerMovement.getDmg(damage);
                    }
                }
                else if (hit.CompareTag("Attacks"))
                {
                    
                    Destroy(hit.gameObject);
                }
            }
        }

        
        Destroy(gameObject);
    }


}

