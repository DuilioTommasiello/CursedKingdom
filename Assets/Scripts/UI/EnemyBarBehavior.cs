using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBarBehavior : MonoBehaviour
{
    [SerializeField] public Slider slider;
    [SerializeField] public new Camera camera;
    [SerializeField] public Transform target;
    [SerializeField] public Vector3 offset;

    public void UpdateHealBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
    private void Update()
    {
        transform.rotation = camera.transform.rotation;
        transform.position = target.position + offset;
    }
}
