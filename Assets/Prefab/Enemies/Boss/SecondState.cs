using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondState : MonoBehaviour
{
    [SerializeField] EnemyLife enemySc;
    [SerializeField] List<Transform> wayPoints;
    public int nextPos = 0;
    public int timer = 0;

    private void Awake()
    {
        enemySc = GetComponent<EnemyLife>();
    }

    private void Update()
    {
        patroll();
    }

    void patroll()
    {
        if(enemySc.EnemLife < enemySc.EnemLife/2)
        {
            Debug.Log("hola marcianete");
        transform.position = wayPoints[0].position;
        timer++;
        
        if (timer >= 3 )
        {
            timer = 0;
            nextPos++;
            transform.position = wayPoints[nextPos].position;
        
        }
        }
    }
}
