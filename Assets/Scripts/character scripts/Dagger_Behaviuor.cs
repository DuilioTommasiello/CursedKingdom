using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger_Behaviuor : MonoBehaviour
{
    MarkusPowers Timers;
    private float _DGcounter;
    [SerializeField]public float _DgAirTime = 1;
    private KeyCode _QPower = KeyCode.Q;
    public int _DgSpeed;
    public bool _boolTest = true;
    public float _DgDestroy = 3f;
    public void FixedUpdate()
    {
        Debug.Log(_DGcounter);
        if(Input.GetKey(_QPower))
        {
            _boolTest = false;
            _DGcounter += Time.deltaTime;
        }
        if(_DGcounter <=_DgAirTime && _boolTest == false)
        {
            DgMove();
        }

        Destroy(gameObject, _DgDestroy);

    }
    void DgMove()
    {
            transform.Translate(Vector2.up * _DgSpeed * Time.fixedDeltaTime);
            _DGcounter += Time.deltaTime;
    }
}
