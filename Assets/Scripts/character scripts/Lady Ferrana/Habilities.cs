using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Habilities : MonoBehaviour
{

    [SerializeField] public Transform basicArea;
    [SerializeField] public GameObject basicAtack;
    [SerializeField] public GameObject Zprefab;
    [SerializeField] public GameObject Xprefab;
    [SerializeField] public GameObject Cprefab;
    [SerializeField] public bool basicReady, Zready, Xready, Cready = true;

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
        if (Zready == false)
        {
            _Xcounter += Time.deltaTime;
        }
        if (_Xcounter >= _XCoolDown && Zready == false)
        {
            _Xcounter = 0;
            Zready = true;
        }
        if (Input.GetKey(_ZPower) && Zready == true)
        {
            wAbility();
        }
        #endregion
        #region Timer Q
        if (Xready == false)
        {
            _Zcounter += Time.deltaTime;
        }
        if (_Zcounter >= _ZCoolDown && Xready == false)
        {
            _Zcounter = 0;
            Xready = true;
        }
        if (Input.GetKey(_CPower) && Xready == true)
        {
            qAbility();
        }
        #endregion
        #region Timer E
        if (Cready == false)
        {
            _Ccounter += Time.deltaTime;
        }
        if (_Ccounter >= _CCoolDown && Cready == false)
        {
            _Ccounter = 0;
            Cready = true;
        }
        if (Input.GetKey(_XPower) && Cready == true)
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
        if (Input.GetKey(_ZPower) && Zready == true)
        {
            Instantiate(Zprefab, basicArea.position, basicArea.rotation);
            Zready = false;
        }
    }
        public virtual void qAbility ()
    {
        if(Input.GetKey(_CPower) && Xready == true)
        {
            Instantiate(Xprefab, basicArea.position, basicArea.rotation);
            Xready = false;

        }
    }
        public virtual void eAbility()
    {
        if(Input.GetKey(_XPower) && Cready == true)
        {
            Instantiate(Cprefab, basicArea.position, basicArea.rotation);
            Cready = false;

        }
    }
}

