using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color defaultColor;
    public Color targetColor = Color.red;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

        defaultColor = spriteRenderer.color;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "Enemies")
        {
            StartCoroutine(ChangeColorCoroutine());
        }
    }

    private System.Collections.IEnumerator ChangeColorCoroutine()
    {
        spriteRenderer.color = targetColor;

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = defaultColor;
    }
}
