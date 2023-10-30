using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocateCharacter : MonoBehaviour
{
    public SwitchCharacter swNum;
    public GameObject ferrna;
    public GameObject markus;

    private void FixedUpdate()
    {
        if (swNum.FeranaIsPLaying == true)
        {
            transform.position = ferrna.transform.position;
        }
        else
        {
            transform.position = markus.transform.position;
        }
    }
}
