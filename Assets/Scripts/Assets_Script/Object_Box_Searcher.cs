using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Box_Searcher : MonoBehaviour
{
    public float _boxHealt = 40;
    public Transform SpawnObject;
    //public List<Sprite> objects = new List<Sprite>();



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
        Debug.Log("box has been hit and has " + _boxHealt + "life");

        }
        
    }
    public void boxDmg (int damage)
    {
        _boxHealt -= damage;

        if (_boxHealt <= 0)
        {
        
            Destroy(gameObject, 2f);
        }
    }


}
