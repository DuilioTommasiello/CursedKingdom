using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondState : MonoBehaviour
{
    [SerializeField] EnemyLife enemySc;
    [SerializeField] BossShot bossShotSC;
    [SerializeField] List<Transform> wayPoints;
    private Vector3 originalPos;
    private float enemyHalflife;
    public int nextPos = 0;
    public float timer = 0;
    public float firstTimer = 0;
    public float finaltimer = 5;
    private Collider2D boxCollider;

    private void Awake()
    {
        originalPos = gameObject.transform.position;
    }
    private void Start()
    {
        enemySc = GetComponent<EnemyLife>();
        boxCollider = GetComponent<Collider2D>();
        bossShotSC = GetComponent<BossShot>();
        enemyHalflife = enemySc.EnemLife / 2;
        bossShotSC.enabled = false;

    }
    private void Update()
    {
        if (nextPos >= wayPoints.Count)
        {
            nextPos = 0;
            return;
        }
        UpdateWaypointsList();
        if (enemySc.EnemLife <= enemyHalflife)
        {
            boxCollider.enabled = false;
            secondState();
        }else
        {
            boxCollider.enabled = true;
        }
        if (wayPoints.Count == 0)
        {
            bossShotSC.enabled=false;
            enemySc.EnemLife -= 1;
            transform.position = originalPos;
            boxCollider.enabled = true;
            Debug.Log("Second state ended, no waypoints left.");

            return;
        }

    }

    void secondState()
    {
        enemySc.EnemLife = enemyHalflife;
        firstTimer += Time.deltaTime;
        if (firstTimer >= finaltimer)
        {
            firstTimer = finaltimer;
            timer += Time.deltaTime;
            if (timer >= 3)
            {
            TeleportToNextWaypoint();
            timer = 0f;
            }
        }
    }

    void TeleportToNextWaypoint()
    {
        bossShotSC.enabled = true;
        if (wayPoints[nextPos] != null)
        {
         transform.position = wayPoints[nextPos].position;
         nextPos++;
        }

    }

    void UpdateWaypointsList()
    {
        if (wayPoints[nextPos] == null)
        {
            wayPoints.Remove(wayPoints[nextPos]);
            nextPos++;
        }

    }
}
