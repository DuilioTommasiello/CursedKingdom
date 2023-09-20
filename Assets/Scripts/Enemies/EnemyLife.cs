using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] public float _EnemLife = 50f;
    private GameObject _enemy;

    private void Update()
    {
    }

    public void GetDamage(int damageRecived)
    {
        _EnemLife -= damageRecived;
        Debug.Log("the enemy has been hit and have " + _EnemLife + "life remaining");
                
        if(_EnemLife <=0)
        {
            Destroy(gameObject);
        }

    }
}
