using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossAttack : MonoBehaviour
{
    public Transform playerTransform;
    public float attackDistance;

    private void SpecialAttack()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            
            if(distanceToPlayer >= attackDistance)
            {

            }

    }
}
    
