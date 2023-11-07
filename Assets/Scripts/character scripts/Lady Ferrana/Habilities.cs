using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Habilities : MonoBehaviour
{
    [Header("animations")]
    [SerializeField] public GameObject characterSprite;
    public bool HasAtacking;



    [SerializeField] public Transform basicArea;
    [SerializeField] public GameObject basicAtack;
    [SerializeField] public GameObject Zprefab;
    [SerializeField] public GameObject Xprefab;
    [SerializeField] public GameObject Cprefab;
    [SerializeField] public bool basicReady, Zready, Xready, Cready = true;
     public bool basicEnd, ZEnd, XEnd, CEnd = false;

    [Header("timers")]
    [SerializeField] public float _BasicCounter, _Zcounter, _Xcounter, _Ccounter;
    [SerializeField] private float _basicCoolDown = 0.5f;
    [SerializeField] public float _ZCoolDown = 1f;
    [SerializeField] public float _XCoolDown = 2f;
    [SerializeField] public float _CCoolDown = 3f;

    [Header("keys")]
    [SerializeField] public KeyCode _ZPower = KeyCode.Z;
    [SerializeField] public KeyCode _XPower = KeyCode.X;
    [SerializeField] public KeyCode _CPower = KeyCode.C;
    [SerializeField] public KeyCode _basicAtack = KeyCode.Space;

    

    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Bauti Scene");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("tuto");
        }
        #region Timers
        #region Timer z
        if (Zready == false)
        {
            _Zcounter += Time.deltaTime;
        }
        if (_Zcounter >= _ZCoolDown && Zready == false)
        {
            _Zcounter = 0;
            ZEnd = true;
            Zready = true;
        }
        if (Input.GetKey(_ZPower) && Zready == true)
        {
            zAbility();
        }
        #endregion
        #region Timer x
        if (Xready == false)
        {
            _Xcounter += Time.deltaTime;
        }
        if (_Xcounter >= _XCoolDown && Xready == false)
        {
            XEnd = true;
            HasAtacking = false;
            _Xcounter = 0;
            Xready = true;
        }
        if (Input.GetKey(_XPower) && Xready == true)
        {
            xAbility();
        }
        #endregion
        #region Timer c
        if (Cready == false)
        {
            _Ccounter += Time.deltaTime;
        }
        if (_Ccounter >= _CCoolDown && Cready == false)
        {
            CEnd = true;
            _Ccounter = 0;
            Cready = true;
        }
        if (Input.GetKey(_CPower) && Cready == true)
        {
            cAbility();
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
            basicEnd = true;
            //HasAtacking = false;
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
            HasAtacking = true;
            Instantiate(basicAtack, basicArea.position, basicArea.rotation);
            basicReady = false;
            basicEnd = false;
        }
    }
        public virtual void zAbility()
    {
        if (Input.GetKey(_ZPower) && Zready == true)
        {
            Instantiate(Zprefab, basicArea.position, basicArea.rotation);
            Zready = false;
        }
    }
        public virtual void xAbility ()
    {
        if(Input.GetKey(_XPower) && Xready == true)
        {
            HasAtacking = true;
            Instantiate(Xprefab, basicArea.position, basicArea.rotation);
            Xready = false;

        }
    }
        public virtual void cAbility()
    {
        if(Input.GetKey(_CPower) && Cready == true)
        {
            HasAtacking = true;
            Instantiate(Cprefab, basicArea.position, basicArea.rotation);
            Cready = false;

        }
    }    
}

