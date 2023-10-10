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
    public void recibeDMG(int dmg)
    {
        Debug.Log("enemy has been hit ");
        _EnemLife -= dmg;
        if(_EnemLife <=0)
        {
            Destroy(gameObject);
        }
    }
}
