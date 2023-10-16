using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHit : MonoBehaviour
{
    public GameObject HitEffect;

    private void Update()
    {
        Instantiate(HitEffect, transform.position, Quaternion.identity);
    }
}
