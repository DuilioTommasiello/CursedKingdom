using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDeath : MonoBehaviour
{
    [SerializeField] public EnemyLife enemySc;
    private Collider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<Collider2D>();
        enemySc = GetComponent<EnemyLife>();

    }
    private void Update()
    {
        if(enemySc.EnemLife >0)
        {
        boxCollider.enabled = false;
        }
    }
}
