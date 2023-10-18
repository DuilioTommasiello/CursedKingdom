using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Habilities : MonoBehaviour
{

    [SerializeField] public Transform basicArea;
    [SerializeField] public GameObject basicAtack;
    [SerializeField] public GameObject Wprefab;
    [SerializeField] public GameObject Qprefab;
    [SerializeField] public GameObject Eprefab;
    [SerializeField] public bool basicReady, Wready, Qready, Eready = true;

    [Header("timers")]
    [SerializeField] private float _BasicCounter, _Qcounter, _Wcounter, _Ecounter, _Rcounter;
    [SerializeField] private float _basicCoolDown = 0.5f;
    [SerializeField] private float _QCoolDown = 1f;
    [SerializeField] private float _WCoolDown = 2f;
    [SerializeField] private float _ECoolDown = 3f;

    [Header("keys")]
    [SerializeField] public KeyCode _WPower = KeyCode.W;
    [SerializeField] public KeyCode _EPower = KeyCode.E;
    [SerializeField] public KeyCode _QPower = KeyCode.Q;
    [SerializeField] public KeyCode _basicAtack = KeyCode.Space;
    [SerializeField] public KeyCode _swapKey = KeyCode.H;

    void FixedUpdate()
    {

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("tuto");
        }

        #region Timers
        #region Timer W
        if (Wready == false)
        {
            _Wcounter += Time.deltaTime;
        }
        if (_Wcounter >= _WCoolDown && Wready == false)
        {
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

        }
    }

        public virtual void wAbility()
    {
        if (Input.GetKey(_WPower) && Wready == true)
        {
            Instantiate(Wprefab, basicArea.position, basicArea.rotation);
            Wready = false;
        }
    }
        public virtual void qAbility ()
    {
        if(Input.GetKey(_QPower) && Qready == true)
        {
            Instantiate(Qprefab, basicArea.position, basicArea.rotation);
            Qready = false;

        }
    }
        public virtual void eAbility()
    {
        if(Input.GetKey(_EPower) && Eready == true)
        {
<<<<<<< HEAD
            Instantiate(Eprefab, basicArea.position, basicArea.rotation);
=======
            Instantiate(Eprefab, secondaryArea.position, basicArea.rotation);
>>>>>>> parent of 5118b0d (creacion del esqueleto con animaciones)
            Eready = false;

        }
    }
}

