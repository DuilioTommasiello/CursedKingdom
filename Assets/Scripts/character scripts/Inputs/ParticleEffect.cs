using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    public ParticleSystem DustVertical;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            CreateDustVertical();
        }
    }
    void CreateDustVertical()
    {
        //DustVertical.Play();
    }
    
}
