using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueletonAttack : MonoBehaviour
{
    public Transform playerTransform; 
    public GameObject objectToInstantiate;
    public float speed = 5.0f;
    public float stopDistance = 2.0f;
    public float instantiationDistance = 1.0f;
    private bool isChasing = true;
    public float attackDistance = 10f;
    public float AttackDuration = 0.1f;

    private void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (isChasing && distanceToPlayer <=attackDistance)
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
        isChasing = false;

        yield return new WaitForSeconds(0.4f);

      
        Vector3 instantiationPosition = DetermineInstantiationPosition();

        GameObject instantiatedObject = Instantiate(objectToInstantiate, instantiationPosition, Quaternion.identity);
        Destroy(instantiatedObject, AttackDuration);

        yield return new WaitForSeconds(0.5f);

        isChasing = true;
    }

    Vector3 DetermineInstantiationPosition()
    {
        Vector3 direction = playerTransform.position - transform.position;
        Vector3 instantiationPosition = transform.position;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                instantiationPosition += Vector3.right * instantiationDistance;
            }
            else
            {
                instantiationPosition += Vector3.left * instantiationDistance;
            }
        }
        else
        {
            if (direction.y > 0)
            {
                instantiationPosition += Vector3.up * instantiationDistance;
            }
            else
            {
                instantiationPosition += Vector3.down * instantiationDistance;
            }
        }

        return instantiationPosition;
    }

}
