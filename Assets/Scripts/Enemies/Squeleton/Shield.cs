using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] EnemyLife EnLi;
    [SerializeField] public BoxCollider2D boxCol;
    public int shieldState;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            shieldState += 1;
        }
    }


    public void Update()
    {
        if (shieldState >= 4)
        {
            boxCol.enabled = true;
            EnLi.enabled = true;
            EnLi.GetComponent<EnemyBarBehavior>();
            Destroy(gameObject);
        }
    }
}
