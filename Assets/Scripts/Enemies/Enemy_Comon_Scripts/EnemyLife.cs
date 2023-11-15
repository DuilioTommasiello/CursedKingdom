using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{

    [Header("Stats")]
    [SerializeField] public float EnemLife, EnemyMaxLife, initialLife;
    private GameObject _enemy;
    [SerializeField] EnemyBarBehavior enemyBar;

    private void Awake()
    {
        EnemLife = EnemyMaxLife;
    }
    private void Start()
    {
        enemyBar = GetComponentInChildren<EnemyBarBehavior>();
        initialLife = EnemyMaxLife;
    }
    public void recibeDMG(float dmg)
    {
        Debug.Log("enemy has been hit and has " + EnemLife + "life remaning ");
        EnemLife -= dmg;
        enemyBar.UpdateHealBar(EnemLife, EnemyMaxLife);
        if (EnemLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
