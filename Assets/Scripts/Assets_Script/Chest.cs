using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite newSprite; // Assign the new sprite in the Unity editor
    public GameObject[] objectOptions; // Assign the prefabs for the new objects in the Unity editor
    public Transform spawnPoint1; // Assign the spawn point for the first new object
    public Transform spawnPoint2; // Assign the spawn point for the second new object
    public float interactionDistance = 2f; // Adjust the distance in the Unity editor

    private SpriteRenderer spriteRenderer;
    private GameObject player;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player"); // Assuming the player has the "Player" tag
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && IsPlayerClose())
        {
            // Change the sprite when V key is pressed and the player is close
            ChangeSprite();
            // Add your interaction logic here
        }
    }

    void ChangeSprite()
    {
        // Change the sprite to the newSprite
        spriteRenderer.sprite = newSprite;

        // Randomly select two objects from the objectOptions array
        GameObject selectedObject1 = objectOptions[Random.Range(0, objectOptions.Length)];
        GameObject selectedObject2 = objectOptions[Random.Range(0, objectOptions.Length)];

        // Instantiate the selected objects at specific points
        Instantiate(selectedObject1, spawnPoint1.position, Quaternion.identity);
        Instantiate(selectedObject2, spawnPoint2.position, Quaternion.identity);
    }

    bool IsPlayerClose()
    {
        // Check if the player is close to the object based on the interactionDistance
        return Vector2.Distance(transform.position, player.transform.position) <= interactionDistance;
    }
}
