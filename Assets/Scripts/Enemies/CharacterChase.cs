using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChase : MonoBehaviour
{

    [Header("chase values")]
    [SerializeField] float chasedistance = 10f;
    public float playerDistance;

    [Header("chase obejective")]
    movement player;
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
            playerDistance = Vector2.Distance(transform.position, ferrana.transform.position);
            if (playerDistance <= chasedistance)
            {
            Debug.Log("esta funcionado 1");
                Vector2 direction = ferrana.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, -angle);
                transform.position = Vector2.MoveTowards(this.transform.position, ferrana.transform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            playerDistance = Vector2.Distance(transform.position, markus.transform.position);
            if (playerDistance <= chasedistance)
            {
            Debug.Log("esta funcionado 2");
                Vector2 direction = markus.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, -angle);
                transform.position = Vector2.MoveTowards(this.transform.position, markus.transform.position, speed * Time.deltaTime);
            }

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
