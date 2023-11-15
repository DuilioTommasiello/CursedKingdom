using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeShot : MonoBehaviour
{
     public EnemyLife enmSC;
    public enemyPath enmPH;

    [Header("bullet objects")]
    public Transform bulletSpawn;
    public GameObject bullet;
    private float bulletTimer;
    private float finalBulletTimer = 4;



    private void FixedUpdate()
    {
        if(enmPH.NeedShot == true)
        {
        bulletTimer += Time.fixedDeltaTime;
        if(enmSC.EnemLife > 0 && bulletTimer >= finalBulletTimer )
        {
            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            bulletTimer = 0;
        }
        }
    }
}
