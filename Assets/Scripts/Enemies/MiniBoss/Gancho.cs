using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gancho : MonoBehaviour
{
    public float pullSpeed = 5f;
    private bool isPulling = false;
    private GameObject player;
    private GameObject miniBoss;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPulling)
        {
            isPulling = true;
            player = collision.gameObject;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(PullPlayer());
        }
    }

    void Update()
    {
        miniBoss = GameObject.FindGameObjectWithTag("MiniBoss");

        if (isPulling && player != null)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, miniBoss.transform.position, pullSpeed * Time.deltaTime);
        }
    }

    IEnumerator PullPlayer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
