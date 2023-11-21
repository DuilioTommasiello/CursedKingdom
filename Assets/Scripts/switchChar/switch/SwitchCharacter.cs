using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCharacter : MonoBehaviour
{
    public GameObject Markus, Ferana, BarFer, BarMark;
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
                BarFer.gameObject.SetActive(false);
                Ferana.transform.position = Markus.transform.position;
                FeranaIsPLaying = true;
                break;

            case 2:
                Markus.gameObject.SetActive(true);
                Ferana.gameObject.SetActive(false);
                BarFer.gameObject.SetActive(false);
                BarFer.gameObject.SetActive(true);
                FeranaIsPLaying = false;

                Markus.transform.position = Ferana.transform.position;
                break;
        }

         }
    
}
