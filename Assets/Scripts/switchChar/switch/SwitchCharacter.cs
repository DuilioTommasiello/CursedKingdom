using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    public GameObject Markus, Ferana;

    int WitchAvatarIsOn = 1;
    private KeyCode SwitchCH = KeyCode.Tab;
    private void Start()
    {
        Markus.gameObject.SetActive(true);
        Ferana.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(SwitchCH))
        {
            switchCharacter();
        }
        
    }


    public void switchCharacter()
    {  

        
        switch (WitchAvatarIsOn)
        {
           
          case 1:
                WitchAvatarIsOn = 2;

                Markus.gameObject.SetActive(false);
                Ferana.gameObject.SetActive(true);
                break;

            case 2:

                WitchAvatarIsOn = 1;

                Markus.gameObject.SetActive(true);
                Ferana.gameObject.SetActive(false);
                break;
        }

         }
    
}
