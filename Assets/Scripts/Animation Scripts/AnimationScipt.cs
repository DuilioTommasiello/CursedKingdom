using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationScipt : MonoBehaviour
{
    public List<GameObject> scenes = new List<GameObject>();
    public List<GameObject> backgrounds = new List<GameObject>();
    public float index = 1.0f;
    private int sceneIndex = 0;
    private int backgroundIndex = 0;
    private int counter = 0;
    public float timer = 0.0f;
    private GameObject previousScene;
    private GameObject previousBackground;

    void Start()
    {
        if (backgrounds.Count > 0)
        {
            backgrounds[0].SetActive(true);
            previousBackground = backgrounds[0];
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= index)
        {
            counter++;

            if (previousScene != null)
            {
                previousScene.SetActive(false);
            }

            if (sceneIndex < scenes.Count)
            {
                scenes[sceneIndex].SetActive(true);
                previousScene = scenes[sceneIndex];
                sceneIndex++;
            }
            else
            {
                sceneIndex = 0;
            }

            timer = 0.0f;

            if (counter == 2)
            {
                if (backgroundIndex < backgrounds.Count)
                {
                    if (previousBackground != null)
                    {
                        previousBackground.SetActive(false);
                    }

                    backgrounds[backgroundIndex].SetActive(true);
                    previousBackground = backgrounds[backgroundIndex];
                    backgroundIndex++;
                }
                else
                {
                    SceneManager.LoadScene("Tutorial");
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (counter == 2)
        {
            counter = 0;
        }
    }
}