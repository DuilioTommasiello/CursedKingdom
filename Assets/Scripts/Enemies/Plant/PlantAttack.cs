using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : MonoBehaviour
{
    public GameObject player;

    public GameObject anticipation;
    public GameObject attack;
    public float attackDistance = 5f;
    public float attackCooldown = 5f;
    private float lastAttackTime;

    void Start()
    {   
        lastAttackTime = Time.time;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= attackDistance && Time.time - lastAttackTime >= attackCooldown)
        {
            // Instantiate an attack object at the player's position
            InstantiateAttackObject(player.transform.position);

            // Update the last attack time
            lastAttackTime = Time.time;
        }
    }

    void InstantiateAttackObject(Vector2 position)
    {
        float timer = 0f;

        GameObject Anticipation = Instantiate(anticipation, position, Quaternion.identity);
        timer += Time.deltaTime;
        Destroy(Anticipation, 1f);
        
        if(timer >= 1f)
        {
            GameObject AttackObject = Instantiate(attack, position, Quaternion.identity);
            Destroy(attack, 1f);
            timer = 0f;
        }
        
    }
}
