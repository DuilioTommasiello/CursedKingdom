using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondState : MonoBehaviour
{
    [SerializeField] EnemyLife enemySc;
    [SerializeField] List<Transform> wayPoints;
    public int nextPos = 0;
    public float timer = 0;
    public float finaltimer = 10;
    private Collider2D boxCollider;


    private void Start()
    {
        boxCollider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if(enemySc.EnemLife == 50 && wayPoints.Count != 0 )
        {
        secondState();            
        }
    }
    void secondState()
    {
        Debug.Log("secondState");
        timer += Time.deltaTime;

        if (timer >= finaltimer)
        {
            timer = 0f;
            TeleportToNextWaypoint();
        }
    }

    void TeleportToNextWaypoint()
    {
        Debug.Log("TeleportToNextWaypoint");
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
        nextPos++;
        if (nextPos >= wayPoints.Count)
        {
            nextPos = 0;
        }
        transform.position = wayPoints[nextPos].position;
    }
}
