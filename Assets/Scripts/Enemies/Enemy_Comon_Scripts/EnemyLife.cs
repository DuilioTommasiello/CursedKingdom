using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{

    [Header("Stats")]
    [SerializeField] public float _EnemLife, _EnemyMaxLife;
    private GameObject _enemy;
    [SerializeField] public EnemyBarBehavior enemyBar;

    private void Start()
    {
        enemyBar = GetComponent<EnemyBarBehavior>();
        _EnemLife = _EnemyMaxLife;
    }
    public void recibeDMG(float dmg)
    {
        Debug.Log("enemy has been hit and has " + _EnemLife + "life remaning ");
        _EnemLife -= dmg;
        enemyBar.UpdateHealBar(_EnemLife, _EnemyMaxLife);
        if (_EnemLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
