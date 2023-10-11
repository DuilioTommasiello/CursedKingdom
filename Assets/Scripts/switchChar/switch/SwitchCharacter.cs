using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCharacter : MonoBehaviour
{
    public GameObject Markus, Ferana;
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
                Ferana.transform.position = Markus.transform.position;
                FeranaIsPLaying = true;
                break;

            case 2:
                Markus.gameObject.SetActive(true);
                Ferana.gameObject.SetActive(false);
                FeranaIsPLaying = false;
                Markus.transform.position = Ferana.transform.position;
                break;
        }

         }
    
}
