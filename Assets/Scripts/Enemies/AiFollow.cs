using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFollow : MonoBehaviour
{
    [SerializeField] public Transform player;

    [SerializeField] public Transform player2;

    [SerializeField] private float distance;

    public Vector3 initialPoint;
   
    private Animator animator;

    private SpriteRenderer spriterender;

    private void Start()
    {
        animator = GetComponent<Animator>();
        initialPoint = transform.position;
        spriterender = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        distance = Vector2.Distance(transform.position, player2.position);
        animator.SetFloat("Distancia", distance);
    }

    public void turn(Vector3 objetive)
    {
        if (transform.position.x < objetive.x)
        {
            spriterender.flipX = true;
        }
        else
        {
            spriterender.flipX = false;
        }
    }
}
