using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCharacter : MonoBehaviour
{
    public GameObject Markus, Ferana;
    public CinemachineVirtualCamera virtualCamera;

    int WitchAvatarIsOn = 0;
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
            virtualCamera.Follow = Markus.transform;
        }
        else if (Input.GetKeyDown(SwitchCH))
        {
            virtualCamera.Follow = Ferana.transform;
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
                break;

            case 2:
                Markus.gameObject.SetActive(true);
                Ferana.gameObject.SetActive(false);
                Markus.transform.position = Ferana.transform.position;
                break;
        }

         }
    
}
