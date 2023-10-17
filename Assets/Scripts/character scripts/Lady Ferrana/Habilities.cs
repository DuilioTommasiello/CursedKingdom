using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Habilities : MonoBehaviour
{

    [SerializeField] public Transform basicArea;
    [SerializeField] public Transform secondaryArea;
    [SerializeField] public GameObject basicAtack;
    [SerializeField] public GameObject Zprefab;
    [SerializeField] public GameObject Xprefab;
    [SerializeField] public GameObject Cprefab;
    [SerializeField] public bool basicReady, Wready, Qready, Eready = true;

    [Header("timers")]
    [SerializeField] private float _BasicCounter, _Zcounter, _Xcounter, _Ccounter;
    [SerializeField] private float _basicCoolDown = 0.5f;
    [SerializeField] private float _ZCoolDown = 1f;
    [SerializeField] private float _XCoolDown = 2f;
    [SerializeField] private float _CCoolDown = 3f;

    [Header("keys")]
    [SerializeField] public KeyCode _ZPower = KeyCode.Z;
    [SerializeField] public KeyCode _XPower = KeyCode.X;
    [SerializeField] public KeyCode _CPower = KeyCode.C;
    [SerializeField] public KeyCode _basicAtack = KeyCode.Space;

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
            _Xcounter += Time.deltaTime;
        }
        if (_Xcounter >= _XCoolDown && Wready == false)
        {
            _Xcounter = 0;
            Wready = true;
        }
        if (Input.GetKey(_ZPower) && Wready == true)
        {
            wAbility();
        }
        #endregion
        #region Timer Q
        if (Qready == false)
        {
            _Zcounter += Time.deltaTime;
        }
        if (_Zcounter >= _ZCoolDown && Qready == false)
        {
            _Zcounter = 0;
            Qready = true;
        }
        if (Input.GetKey(_CPower) && Qready == true)
        {
            qAbility();
        }
        #endregion
        #region Timer E
        if (Eready == false)
        {
            _Ccounter += Time.deltaTime;
        }
        if (_Ccounter >= _CCoolDown && Eready == false)
        {
            _Ccounter = 0;
            Eready = true;
        }
        if (Input.GetKey(_XPower) && Eready == true)
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
        if (Input.GetKey(_ZPower) && Wready == true)
        {
            Instantiate(Zprefab, basicArea.position, basicArea.rotation);
            Wready = false;
        }
    }
        public virtual void qAbility ()
    {
        if(Input.GetKey(_CPower) && Qready == true)
        {
            Instantiate(Xprefab, basicArea.position, basicArea.rotation);
            Qready = false;

        }
    }
        public virtual void eAbility()
    {
        if(Input.GetKey(_XPower) && Eready == true)
        {
            Instantiate(Cprefab, secondaryArea.position, basicArea.rotation);
            Eready = false;

        }
    }
}

