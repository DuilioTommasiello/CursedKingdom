using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float movSpeed;

    [SerializeField] private Transform[] wayPoints;

    [SerializeField] private float minDistance;

    private int randomNumber;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        randomNumber = Random.Range(0, wayPoints.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        turn();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[randomNumber].position, movSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoints[randomNumber]. position)<minDistance)
        {
            randomNumber = Random.Range(0, wayPoints.Length);

            turn();
        }
    }

    private void turn()
    {
        if (transform.position.x < wayPoints[randomNumber].position.x )
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
