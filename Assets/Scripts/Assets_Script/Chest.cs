using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    
    public Sprite newSprite;
    public GameObject[] objectOptions;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public float interactionDistance = 2f;

    private SpriteRenderer spriteRenderer;
    public GameObject Ferana;
    public GameObject Markus;
    private bool hasInteracted = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!hasInteracted && Input.GetKeyDown(KeyCode.V) && IsFeranaClose() || !hasInteracted && Input.GetKeyDown(KeyCode.V) && IsMarkusClose())
        {
            ChangeSprite();
        }
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;

        GameObject selectedObject1 = objectOptions[Random.Range(0, objectOptions.Length)];
        GameObject selectedObject2 = objectOptions[Random.Range(0, objectOptions.Length)];

        Instantiate(selectedObject1, spawnPoint1.position, Quaternion.identity);
        Instantiate(selectedObject2, spawnPoint2.position, Quaternion.identity);

        
        hasInteracted = true;
    }

    bool IsFeranaClose()
    {
        return Vector2.Distance(transform.position, Ferana.transform.position) <= interactionDistance;
    }
    bool IsMarkusClose()
    {
        return Vector2.Distance(transform.position, Markus.transform.position) <= interactionDistance;
    }
}
