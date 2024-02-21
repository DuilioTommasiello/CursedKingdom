using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueletonAttack : MonoBehaviour
{
    public Transform playerTransform; // Assign in the inspector
    public GameObject objectToInstantiate; // Assign your prefab in the inspector
    public GameObject specialBullet;
    public float speed = 5.0f;
    public float stopDistance = 2.0f;
    public float instantiationDistance = 1.0f; // Distance from the enemy to instantiate the object
    private bool isChasing = true;

    private void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= stopDistance)
        {
            if (isChasing)
            {
                StartCoroutine(StopAndChase());
            }
        }
        else
        {
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            transform.position += directionToPlayer * speed * Time.deltaTime;
        }
    }

    IEnumerator StopAndChase()
    {
        isChasing = false; // Stop chasing

        // Wait for 0.5 seconds before instantiating the object
        yield return new WaitForSeconds(0.4f);

        // Determine the instantiation position based on player's relative position
        Vector3 instantiationPosition = DetermineInstantiationPosition();

        // Instantiate the object at the calculated position and immediately schedule for destruction
        GameObject instantiatedObject = Instantiate(objectToInstantiate, instantiationPosition, Quaternion.identity);
        Destroy(instantiatedObject, 0.1f); // Destroy the object after 0.1 second

        // Wait for another 0.5 seconds to complete the 1 second wait
        yield return new WaitForSeconds(0.5f);

        isChasing = true; // Resume chasing
    }

    Vector3 DetermineInstantiationPosition()
    {
        Vector3 direction = playerTransform.position - transform.position;
        Vector3 instantiationPosition = transform.position;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Instantiate to the left or right
            if (direction.x > 0)
            {
                // Player is to the right
                instantiationPosition += Vector3.right * instantiationDistance;
            }
            else
            {
                // Player is to the left
                instantiationPosition += Vector3.left * instantiationDistance;
            }
        }
        else
        {
            // Instantiate above or below
            if (direction.y > 0)
            {
                // Player is above
                instantiationPosition += Vector3.up * instantiationDistance;
            }
            else
            {
                // Player is below
                instantiationPosition += Vector3.down * instantiationDistance;
            }
        }

        return instantiationPosition;
    }

}
