using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    public GameObject attackObjectPrefab;
    public GameObject finalObjectPrefab;
    public GameObject bulletSpawn;
    public GameObject bullet;
    public float attackDistance = 5f;
    public float attackCooldown = 1f;
    public float finalObjectDelay = 1f;
    public float finalObjectDuration = 2f;
    public float bulletTimer = 0;
    public float finalBulletTimer = 4f;

    public GameObject player;
    private float lastAttackTime;

    void Start()
    {
        lastAttackTime = Time.time;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        bulletTimer += Time.deltaTime;

        if (distanceToPlayer <= attackDistance && Time.time - lastAttackTime >= attackCooldown && distanceToPlayer >= 3)
        {
            InstantiateAttackObject(player.transform.position);

            lastAttackTime = Time.time;
        }

        if (distanceToPlayer < 3 && Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
        }

        if (bulletTimer >= finalBulletTimer)
        {
            Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
            bulletTimer = 0;
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


}
