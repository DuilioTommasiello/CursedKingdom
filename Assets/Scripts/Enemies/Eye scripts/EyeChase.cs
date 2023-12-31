using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeChase : MonoBehaviour
{

    [Header("chase values")]
    [SerializeField] float chasedistance = 10f;
    [SerializeField] float stopDistance = 5;
    public float playerDistance;

    [Header("chase obejective")]
    movement player;
    public SwitchCharacter swNum;
    public GameObject ferrana;
    public GameObject markus;
    public float speed = 2.5f;
    private float distance;


        void Update()
        {
        if (swNum.FeranaIsPLaying == true)
        {
            int layerMask = LayerMask.GetMask("walls");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, ferrana.transform.position, 1f, layerMask);
            playerDistance = Vector2.Distance(transform.position, ferrana.transform.position);
            if (playerDistance <= chasedistance && playerDistance > stopDistance && hit.collider == null)
            {
                Vector2 direction = ferrana.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                transform.position = Vector2.MoveTowards(this.transform.position, ferrana.transform.position, speed * Time.deltaTime);
            }else if(playerDistance <= 4 )
            {
                Vector2 direction = ferrana.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                transform.position = Vector2.MoveTowards(this.transform.position, - ferrana.transform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            int layerMask = LayerMask.GetMask("walls");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, markus.transform.position, 1f, layerMask);
            playerDistance = Vector2.Distance(transform.position, markus.transform.position);
            if (playerDistance <= chasedistance && playerDistance > stopDistance && hit.collider == null)
            {
                Vector2 direction = markus.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                transform.position = Vector2.MoveTowards(this.transform.position, markus.transform.position, speed * Time.deltaTime);
            }else
            {
                Vector2 direction = markus.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                transform.position = Vector2.MoveTowards(this.transform.position, - markus.transform.position, speed * Time.deltaTime);
            }

        }
        }

}
