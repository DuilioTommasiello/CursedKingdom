using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Box_Searcher : MonoBehaviour
{
    public float _boxHealt = 40;
    public Transform spawnPoint;
    public List<GameObject> objects = new List<GameObject>();


    private void FixedUpdate()
    {
        if (_boxHealt <= 0)
        {
            drop();
        }
    }

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
    }

    void drop()
    {
        var Random = UnityEngine.Random.Range(0, (objects.Count + 1));
        if (Random == 0)
        {
            Instantiate(objects[0], spawnPoint.position, spawnPoint.rotation);
            Destroy(gameObject);

        }
        else if (Random == 1)
        {
            Instantiate(objects[1], spawnPoint.position, spawnPoint.rotation);
            Destroy(gameObject);


        }
        else if (Random == 2)
        {
            Instantiate(objects[2], spawnPoint.position, spawnPoint.rotation);
            Destroy(gameObject);

        }




    }


}
