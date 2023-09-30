using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Box_Searcher : MonoBehaviour
{
    [Header("scripts references")]
    public AtackTimers Atacks;

    public float _boxHealt = 40;
    public GameObject _destructableObject;
    public List<GameObject> objects = new List<GameObject>();    
    void Start()
    {
        
    }

    void Update()
    {
        _boxHealt -= 2 *Time.deltaTime;

        if (_boxHealt <= 0)
        {
            Destroy(_destructableObject);
            var randomNum = Random.Range(0, (6 + 1));
            Instantiate(objects[randomNum]);
        }

    }
    //public void BoxDamage(int damageRecived)
    //{
    //    _boxHealt -= damageRecived;

    //}

}
