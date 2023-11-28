using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : MonoBehaviour
{
    public int Vida;
    public GameObject attackObjectPrefab;
    public GameObject finalObjectPrefab;
    public GameObject MeleeAttack;
    public float attackDistance = 5f;
    public float attackCooldown = 1f;
    public float finalObjectDelay = 1f;
    public float finalObjectDuration = 2f;

    public GameObject player;
    private float lastAttackTime;

    void Start()
    {
        lastAttackTime = Time.time;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= attackDistance && Time.time - lastAttackTime >= attackCooldown && distanceToPlayer >= 3)
        {
            InstantiateAttackObject(player.transform.position);

            lastAttackTime = Time.time;
        }

        if(distanceToPlayer < 3 && Time.time - lastAttackTime >= attackCooldown)
        {
            InstantiateMeleeAttack(player.transform.position);
            lastAttackTime = Time.time;
        }
    }

    void InstantiateAttackObject(Vector2 position)
    {
        GameObject attackObject = Instantiate(attackObjectPrefab, position, Quaternion.identity);

        StartCoroutine(WaitAndInstantiateFinalObject(attackObject));
    }

    IEnumerator WaitAndInstantiateFinalObject(GameObject attackObject)
    {
        yield return new WaitForSeconds(finalObjectDelay);

        GameObject finalObject = Instantiate(finalObjectPrefab, attackObject.transform.position, Quaternion.identity);

        Destroy(attackObject);

        Destroy(finalObject, finalObjectDuration);
    }

    void InstantiateMeleeAttack(Vector2 position)
    {
        GameObject attackObject = Instantiate(MeleeAttack, position, Quaternion.identity);
        Destroy(attackObject, 0.2f);
    }
}

