using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossAttack : MonoBehaviour
{
    public float stoppingDistance = 2f;
    public float shootingRange = 10f;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float bulletSpeed = 20f;
    public float cooldown = 15f;

    public Transform target;
    private float timeSinceLastShot;
    private bool isCooldownTimerActive = false;

    public SqueletonAttack otherComponent;

    void Start()
    {
        otherComponent = GetComponent<SqueletonAttack>();

        timeSinceLastShot = cooldown;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if (distanceToPlayer <= shootingRange && !isCooldownTimerActive)
        {
            isCooldownTimerActive = true;
        }

        if (distanceToPlayer <= shootingRange && distanceToPlayer > stoppingDistance && timeSinceLastShot >= cooldown)
        {
            // Dispara al jugador
            ShootAtPlayer();
            timeSinceLastShot = 0f;
        }

        if (isCooldownTimerActive && timeSinceLastShot < cooldown)
        {
            timeSinceLastShot += Time.deltaTime;
        }
    }

    void ShootAtPlayer()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        Vector2 direction = (target.position - shootingPoint.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        if (otherComponent != null)
        {
            otherComponent.enabled = false;
            StartCoroutine(ReactivateOtherComponentAfterDelay(2f));
        }

        Destroy(bullet, 5f);
    }
    IEnumerator ReactivateOtherComponentAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (otherComponent != null)
        {
            otherComponent.enabled = true;
        }
    }
}


