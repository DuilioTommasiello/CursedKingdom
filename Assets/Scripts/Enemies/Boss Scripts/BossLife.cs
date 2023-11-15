using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    [SerializeField] public float _bossLife;

    public void recibeDMG(float dmg)
    {
        Debug.Log("boss has been hit and has " + _bossLife + "life remaning ");
        _bossLife -= dmg;
        if (_bossLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
