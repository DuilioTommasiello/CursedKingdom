using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvenSpecia : MonoBehaviour
{
    public SwitchCharacter SwCh;
    public GameObject Ferrana;
    public GameObject Markus;
    public bool ChInRoom;
    public Transform GlobalTp;
    private KeyCode Tp = KeyCode.E;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (Input.GetKeyDown(Tp) && SwCh.FeranaIsPLaying == true)
            {
                Debug.Log("Ferana tp");
                Ferrana.transform.position = GlobalTp.transform.position;
                ChInRoom = true;
                if (ChInRoom == true)
                {
                    SwCh.enabled = false;
                }
            }
            if (Input.GetKeyDown(Tp) && SwCh.FeranaIsPLaying == false)
            {
                Debug.Log("Markus tp");
                Markus.transform.position = GlobalTp.transform.position;
                ChInRoom = true;
                if (ChInRoom == true)
                {
                    SwCh.enabled = false;
                }
            }
            
        }
    }

}
