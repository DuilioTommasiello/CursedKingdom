using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicArrow : MonoBehaviour
{
    Habilities habilitiesScript;
    public GameObject hitEffect;
    public GameObject Arrow;
    public float effectTimer;

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

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8 || collision.gameObject.layer == 9 || collision.gameObject.layer == 6 )
        {
        Destroy(gameObject);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, effectTimer);
        }
        
    }
}
