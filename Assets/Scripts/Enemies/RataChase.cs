using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RataChase : MonoBehaviour
{
    movement mov;
    public SwitchCharacter swNum;
    public GameObject ferrana;
    public GameObject markus;
    public float speed = 2.5f;
    public int damage = 5;

    private float distance;
 



    void Update()
    {
        if (swNum.FeranaIsPLaying == true)
        {

            distance = Vector2.Distance(transform.position, ferrana.transform.position);
            Vector2 direction = ferrana.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -angle);
            transform.position = Vector2.MoveTowards(this.transform.position, ferrana.transform.position, speed * Time.deltaTime);

        }
        else
        {
            distance = Vector2.Distance(transform.position, markus.transform.position);
            Vector2 direction = markus.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -angle);
            transform.position = Vector2.MoveTowards(this.transform.position, markus.transform.position, speed * Time.deltaTime);
 
        }
    }
    private void OnTriggerStay(Collider other)
    {
        movement player = other.gameObject.GetComponent<movement>();

        if (other.gameObject.layer == 3)
        {

            Debug.Log("the rat has hit something");
            player.getDmg(damage);

        }
    }


}
