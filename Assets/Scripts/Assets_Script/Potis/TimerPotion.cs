using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPotion : MonoBehaviour
{
    [SerializeField] Habilities HabF;
    [SerializeField] Habilities HabM;
    public GameObject Mark;
    public GameObject fera;
    public SwitchCharacter swCh;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && collision != null)
        {
            if (HabF.Zready == false && swCh.FeranaIsPLaying == true)
            {
                Debug.Log("Reset");
                HabF.Zready = true;
                Destroy(gameObject);
            }
            if (HabF.Xready == false && swCh.FeranaIsPLaying == true)
            {
                Debug.Log("Reset");
                HabF.Xready = true;
                Destroy(gameObject);
            }
            if (HabF.Cready == false && swCh.FeranaIsPLaying == true)
            {
                Debug.Log("Reset");
                HabF.Cready = true;
                Destroy(gameObject);
            }
            if (HabM.Zready == false &&  swCh.FeranaIsPLaying == false)
            {
                Debug.Log("Reset");
                HabM.Zready = true;
                Destroy(gameObject);
            }
            if (HabM.Xready == false && swCh.FeranaIsPLaying == false)
            {
                Debug.Log("Reset");
                HabM.Xready = true;
                Destroy(gameObject);
            }
            else if (HabM.Cready == false && swCh.FeranaIsPLaying == false)
            {
                Debug.Log("Reset");
                HabM.Cready = true;
                Destroy(gameObject);
            }
        }
    }
}
