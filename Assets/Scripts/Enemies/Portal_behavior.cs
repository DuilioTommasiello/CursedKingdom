using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_behavior : MonoBehaviour
{
    public SwitchCharacter swNum;
    private enemyPath enmySC;
    public GameObject ferrana;
    public GameObject markus;

    [Header("chase values")]
    public float chasedistance = 10f;
    public float playerDistance;

    public Transform bulletSpawn;
    public GameObject bullet;
    public new List<Transform> Spawns = new List<Transform>();
    private int nextPos = 0;
    private float timer;




    private void FixedUpdate()
    {
        distanceCalc();

        if (playerDistance > chasedistance)
        {
            PortalShoot();
        }
        else if (playerDistance < chasedistance)    
        {
            portalChange();
            nextPos++;
            if (nextPos >= 4)
            {
                nextPos = 0;
            }
        }


    }

    public void distanceCalc()
    {
        if (swNum.FeranaIsPLaying == true)
        {

            playerDistance = Vector2.Distance(transform.position, ferrana.transform.position);

        }
        else
        {
            playerDistance = Vector2.Distance(transform.position, markus.transform.position);
        }
    }

    public void PortalShoot()
    {
        timer += Time.fixedDeltaTime;
        if(timer >= 2)
        {
            Instantiate(bullet,bulletSpawn);
            timer = 0;
        }
    }
   
    void portalChange()
    {
        transform.position = Spawns[nextPos].position;
    }
}
