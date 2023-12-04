using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] EnemyLife enem;
    public Collider2D collider;
    public SpriteRenderer spritecollider;

    private void Update()
    {
        if (enem == null)
        {
            collider.enabled = true;
            spritecollider.enabled = true;
        }
        else
        {
            collider.enabled = false;
            spritecollider.enabled = false;
        }
    }
}
