using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicArrow : MonoBehaviour
{
    Habilities habilitiesScript;

    [Header("Values")]
    [SerializeField] public float distance;
    [SerializeField] public float _atackSpeed;
    [SerializeField] public float _destroyTime = 1.5f;
    [SerializeField] private KeyCode _basicAtack = KeyCode.Space;

    public void Update()
    {
        transform.Translate(Vector3.up * _atackSpeed * Time.deltaTime);
        Destroy(gameObject,_destroyTime);


    }

    void atackMove()
    {

    }
}