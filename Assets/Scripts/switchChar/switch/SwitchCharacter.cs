using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCharacter : MonoBehaviour
{
    public GameObject Markus, Ferana, BarFer, BarMark;
    public GameObject FerSpc, Fer1, Fer2, Fer3;
    public GameObject MarSpc, Mar1, Mar2;
    public CinemachineVirtualCamera virtualCamera;
    

    public int WitchAvatarIsOn = 0;
    public bool FeranaIsPLaying;
    private KeyCode SwitchCH = KeyCode.Tab;
    private void Start()
    {
        switchCharacter();
    }

    public void Update()
    {
        if (Input.GetKeyDown(SwitchCH))
        {
            
            switchCharacter();
            

        }
        else if (Input.GetKeyDown(SwitchCH))
        {
            
        }
    }

    public void switchCharacter()
    {   
        

        WitchAvatarIsOn++;

        if (WitchAvatarIsOn > 2)
            WitchAvatarIsOn = 1;


        switch (WitchAvatarIsOn)
        {
          
          case 1:

                Markus.gameObject.SetActive(false);
                Ferana.gameObject.SetActive(true);
                BarFer.gameObject.SetActive(true);
                BarMark.gameObject.SetActive(false);
                FerSpc.gameObject.SetActive(true);
                Fer1.gameObject.SetActive(true);
                Fer2.gameObject.SetActive(true);
                Fer3.gameObject.SetActive(true);
                MarSpc.gameObject.SetActive(false);
                Mar1.gameObject.SetActive(false);
                Mar2.gameObject.SetActive(false);
                Ferana.transform.position = Markus.transform.position;
                FeranaIsPLaying = true;
                break;

            case 2:
                Markus.gameObject.SetActive(true);
                Ferana.gameObject.SetActive(false);
                BarFer.gameObject.SetActive(false);
                BarMark.gameObject.SetActive(true);
                FerSpc.gameObject.SetActive(false);
                Fer1.gameObject.SetActive(false);
                Fer2.gameObject.SetActive(false);
                Fer3.gameObject.SetActive(false);
                MarSpc.gameObject.SetActive(true);
                Mar1.gameObject.SetActive(true);
                Mar2.gameObject.SetActive(true);
                Markus.transform.position = Ferana.transform.position;
                FeranaIsPLaying = false;
                
                break;
        }

         }
    
}
