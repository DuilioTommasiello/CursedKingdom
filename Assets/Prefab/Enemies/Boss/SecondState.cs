using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondState : MonoBehaviour
{
    [SerializeField] EnemyLife enemySc;
    [SerializeField] List<Transform> wayPoints;
    private Vector3 originalPos;
    public int nextPos = 0;
    public float enemyHalflife;
    public float timer = 0;
    public float finaltimer = 10;
    private Collider2D boxCollider;

    private void Awake()
    {
        originalPos = gameObject.transform.position;
    }
    private void Start()
    {
        enemySc = GetComponent<EnemyLife>();
        boxCollider = GetComponent<Collider2D>();
        enemyHalflife = enemySc.EnemLife / 2;

    }
    private void Update()
    {
        if (enemySc.EnemLife == enemyHalflife && wayPoints.Count != 0)
        {
            secondState();
            boxCollider.enabled = false;
        }

    }
    void secondState()
    {
        if (enemySc.EnemLife < enemySc.EnemLife / 2)
            Debug.Log("secondState");
        timer += Time.deltaTime;
        if (timer >= finaltimer)
        {
            Debug.Log("hola marcianete");
            transform.position = wayPoints[0].position;
            timer++;

            if (timer >= 3)
            {
                timer = 0f;
            TeleportToNextWaypoint();
            }
        }
    }
    void TeleportToNextWaypoint()
    {
        if (boxCollider = null)
        {
            timer = 0;
            nextPos++;
            transform.position = wayPoints[nextPos].position;
        }
        Debug.Log("TeleportToNextWaypoint");
        nextPos++;
        if (nextPos >= wayPoints.Count)
        {
            nextPos = 0;
        }
        if (nextPos >= wayPoints.Count || wayPoints[nextPos] == null)
        {
            UpdateWaypointsList();
            return;
        }
        transform.position = wayPoints[nextPos].position;
    }


    void UpdateWaypointsList()
    {
        Debug.Log("UpdateWaypointsList");
        if (wayPoints[nextPos] == null)
        {
            wayPoints.Remove(wayPoints[nextPos]);
            Debug.Log("se borro el waypoint 5");
        }
        //wayPoints.RemoveAll(item => item == null);

        if (wayPoints.Count == 0)
        {
            EndSecondState();
            return;
        }

        //nextPos = 0;
        //transform.position = wayPoints[nextPos].position;
        Debug.Log("no next pos");
    }

    void EndSecondState()
    {
        transform.position = originalPos;
        Debug.Log("Second state ended, no waypoints left.");
    }
}
