using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Box_Searcher : MonoBehaviour
{

    public float _boxHealt = 40;
    public List<GameObject> objects = new List<GameObject>();    

    void Update()
    {

        if (_boxHealt <= 0)
        {
            var randomNum = Random.Range(0, (6 + 1));
            Instantiate(objects[randomNum]);
            Destroy(gameObject);
        }
    }
    public void recibeDMG(int dmg)
    {
        Debug.Log("box has been hit ");

        _boxHealt -= dmg;
        if (_boxHealt <= 0)
        {
            Destroy(gameObject);
        }
    }
}
