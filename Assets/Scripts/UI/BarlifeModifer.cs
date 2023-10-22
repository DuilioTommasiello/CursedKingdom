using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarlifeModifer : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void changeMaxLife(float maxLife)
    {
        slider.maxValue = maxLife;
    }

    public void changeActulLife(float lifeValue)
    {
        slider.value = lifeValue;
    }

    public void initialBarLife(float lifeQuantiti)
    {
        changeMaxLife(lifeQuantiti);
        changeActulLife(lifeQuantiti);
    }
}
