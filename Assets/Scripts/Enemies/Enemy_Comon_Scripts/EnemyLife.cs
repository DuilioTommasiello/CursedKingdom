using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{

    [Header("Stats")]
    [SerializeField] public float _EnemLife;
    //[SerializeField] public float _EnemyMaxLife;
    private GameObject _enemy;
    public EnemyBarBehavior healtBar;
    

    private void Start()
    {
        //healtBar.setHealth(_EnemLife, _EnemyMaxLife);
    }
    private void Update()
    {
        //healtBar.setHealth(_EnemLife, _EnemyMaxLife);
    }

    public void recibeDMG(int dmg)
    {
        //healtBar.setHealth(_EnemLife, _EnemyMaxLife);
        Debug.Log("enemy has been hit and has " + _EnemLife + "life remaning ");
        _EnemLife -= dmg;
        if (_EnemLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
