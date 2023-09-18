using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject[] allMenues;
    public GameObject wantedActiveMenue;
    public Object sceneToChange;

     void Awake()
    {
         foreach(var menu in allMenues)
        {
            menu.SetActive(false);
        }
        if (wantedActiveMenue != null) wantedActiveMenue.SetActive(true);
    }

    public void changeMyScene(Object sceneToChange)
    {
        SceneManager.LoadScene(1);
    }

    public void restarLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else     
        Application.Quit();
#endif
    }
}
