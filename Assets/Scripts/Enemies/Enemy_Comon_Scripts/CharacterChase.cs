using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChase : MonoBehaviour
{
    public Vector2 direction;
    [Header("chase values")]
    [SerializeField] public float chasedistance = 10f;
    public float playerDistance;

    [Header("chase obejective")]
    movement player;
    public SwitchCharacter swNum;
    public GameObject ferrana;
    public GameObject markus;
    public float speed = 3f;
    public int damage = 5;
    private float distance;


        void Update()
        {
        if (swNum.FeranaIsPLaying == true)
        {
            chaseF();
        }
        else
        {
            chaseM();
        }
    }
    public void chaseF() 
    {
        int layerMask = LayerMask.GetMask("walls");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, ferrana.transform.position, 1f, layerMask);
        playerDistance = Vector2.Distance(transform.position, ferrana.transform.position);
        if (playerDistance <= chasedistance && hit.collider == null)
        {
            Vector2 direction = ferrana.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -angle);
            transform.position = Vector2.MoveTowards(this.transform.position, ferrana.transform.position, speed * Time.deltaTime);
        }
    }
    public void chaseM() 
    {
        playerDistance = Vector2.Distance(transform.position, markus.transform.position);
        if (playerDistance <= chasedistance)
        {
            Vector2 direction = markus.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -angle);
            transform.position = Vector2.MoveTowards(this.transform.position, markus.transform.position, speed * Time.deltaTime);
        }
    }



}
