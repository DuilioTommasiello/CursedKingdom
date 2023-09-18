using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject deafetedMenu;

    public void PauseLevel(bool pause)
    {
        if (pause) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

   public void DeafetedMenu()
    {
        deafetedMenu.SetActive(true);
        PauseLevel(true);
    }
}
