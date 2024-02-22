using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Habilities : MonoBehaviour
{
    [Header("animations")]
    [SerializeField] ScriptAnimations animations;
    public bool HasAtacking;
    private float timerAnim;

    [SerializeField] public Transform basicArea;
    [SerializeField] public GameObject basicAtack;
    [SerializeField] public GameObject Zprefab;
    [SerializeField] public GameObject Xprefab;
    [SerializeField] public GameObject Cprefab;
    [SerializeField] public bool basicReady, Zready, Xready, Cready = true;
     public bool basicEnd, ZEnd, XEnd, CEnd = false;

    [Header("timers")]
    [SerializeField] public float _BasicCounter, _Zcounter, _Xcounter, _Ccounter;
    [SerializeField] public float _basicCoolDown = 0.5f;
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
        cancelAnim();
        
        
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
            _Ccounter = 0;
            CEnd = true;
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
            animations.isAtacking = true;
            animations.WichAtack = 0;
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
            animations.isAtacking = true;
            animations.WichAtack = 1;
            Instantiate(Xprefab, basicArea.position, basicArea.rotation);
            Xready = false;

        }
    }
        public virtual void cAbility()
    {
        if(Input.GetKey(_CPower) && Cready == true)
        {
            animations.isAtacking = true;
            animations.WichAtack = -1;
            Instantiate(Cprefab, basicArea.position, basicArea.rotation);
            Cready = false;

        }
    }    
       void cancelAnim()
        {     
        
           if (animations.isAtacking == true)
           { 
            timerAnim += Time.deltaTime;
               if(timerAnim >= 3)
               {
                   animations.isAtacking = false;
               }
           }
        }
}

