using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLife : MonoBehaviour
{
    public float life = 60;

    public void PlatDMG(float dmg)
    {
        Debug.Log("plaform has been hit and has " + life + "life remaning ");
        life -= dmg;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
