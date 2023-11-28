using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomCamera : MonoBehaviour
{
    public bool ZoomActive;
    public Vector3[] Target;
    public CinemachineVirtualCamera virtualCamera;
    public float Speed;

    
    private void LateUpdate()
    {
        if (ZoomActive == true)
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, 9f, Speed);
        }
        else if (ZoomActive == false)
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, 6f, Speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ZoomActive = true;
        }
    }
}
