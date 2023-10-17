using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicArrow : MonoBehaviour
{
    Habilities habilitiesScript;
    public GameObject hitEffect;
    public GameObject Arrow;

    [Header("Values")]
    [SerializeField] public float distance;
    [SerializeField] public float _atackSpeed;
    [SerializeField] public float _destroyTime = 1.5f;

    public void Update()
    {
        transform.Translate(Vector3.up * _atackSpeed * Time.deltaTime);
        Destroy(gameObject,_destroyTime);

    }


    void atackMove()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.375f);
                Destroy(gameObject);  
    }
}
