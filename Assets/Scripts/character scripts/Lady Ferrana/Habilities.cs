using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilities : MonoBehaviour
{
    [SerializeField] public Transform basicArea;
    [SerializeField] public GameObject basicAtack;
    [SerializeField] public GameObject Wprefab;
    [SerializeField] public GameObject Qprefab;
    [SerializeField] public GameObject Eprefab;
    [SerializeField] public bool basicReady, Wready, Qready, Eready, Rready = true;

    [Header("timers")]
    [SerializeField] private float _BasicCounter, _Qcounter, _Wcounter, _Ecounter, _Rcounter;
    [SerializeField] private float _basicCoolDown = 0.5f;
    [SerializeField] private float _QCoolDown = 1f;
    [SerializeField] private float _WCoolDown = 2f;
    [SerializeField] private float _ECoolDown = 3f;
    [SerializeField] private float _RCoolDown = 0.5f;

    [Header("keys")]
    [SerializeField] private KeyCode _WPower = KeyCode.W;
    [SerializeField] private KeyCode _EPower = KeyCode.E;
    [SerializeField] private KeyCode _RPower = KeyCode.R;
    [SerializeField] private KeyCode _QPower = KeyCode.Q;
    [SerializeField] private KeyCode _basicAtack = KeyCode.Space;
    [SerializeField] private KeyCode _swapKey = KeyCode.H;



    void Start()
    {

    }

    void FixedUpdate()
    {
        #region Timers
        #region Timer W
        if (Wready == false)
        {
            _Wcounter += Time.deltaTime;
        }
        if (_Wcounter >= _WCoolDown && Wready == false)
        {
            Debug.Log("The W timer has been reset");
            _Wcounter = 0;
            Wready = true;
        }
        if (Input.GetKey(_WPower) && Wready == true)
        {
            wAbility();
        }
        #endregion
        #region Timer Q
        if (Qready == false)
        {
            _Qcounter += Time.deltaTime;
        }
        if (_Qcounter >= _QCoolDown && Qready == false)
        {
            Debug.Log("The Q timer has been reset");
            _Qcounter = 0;
            Qready = true;
        }
        if (Input.GetKey(_QPower) && Qready == true)
        {
            qAbility();
        }
        #endregion
        #region Timer E
        if (Eready == false)
        {
            _Ecounter += Time.deltaTime;
        }
        if (_Ecounter >= _ECoolDown && Eready == false)
        {
            Debug.Log("The E timer has been reset");
            _Ecounter = 0;
            Eready = true;
        }
        if (Input.GetKey(_EPower) && Eready == true)
        {
            eAbility();
        }
        #endregion
        #region Timer Basic
        if (basicReady == false)
        {
            _BasicCounter += Time.deltaTime;
        }
        if (_BasicCounter >= _basicCoolDown && basicReady == false)
        {
            Debug.Log("The basic timer has been reset");
            _BasicCounter = 0;
            basicReady = true;
        }
        if (Input.GetKey(_basicAtack) && basicReady == true)
        {
            basicAtacks();
        }
        #endregion

        
        #endregion
    }


        public virtual void basicAtacks()
    {
        if (Input.GetKey(_basicAtack) && basicReady == true)
        {
            Instantiate(basicAtack, basicArea.position, basicArea.rotation);
            basicReady = false;
            Debug.Log(" you have use the Space");

        }
    }

        public virtual void wAbility()
    {
        if (Input.GetKey(_WPower) && Wready == true)
        {
            Instantiate(Wprefab, basicArea.position, basicArea.rotation);
            Wready = false;
            Debug.Log(" you have use the W");
        }
    }
        public virtual void qAbility ()
    {
        if(Input.GetKey(_QPower) && Qready == true)
        {
            Instantiate(Qprefab, basicArea.position, basicArea.rotation);
            Qready = false;
            Debug.Log("you have use the Q");

        }
    }
        public virtual void eAbility()
    {
        if(Input.GetKey(_EPower) && Eready == true)
        {
            Instantiate(Eprefab, basicArea.position, basicArea.rotation);
            Eready = false;
            Debug.Log("You hace use the W");

        }
    }
}

