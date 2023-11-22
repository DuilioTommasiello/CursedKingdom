using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownScripts : MonoBehaviour
{
     public Habilities coldwn;

    [Header("Spc")]
    public Image abilityImgaeSp;
    bool isCoolDownSpc = false;
    [Header("Z")]
    public Image abilityImgae1;
    bool isCoolDown = false;
    [Header("X")]
    public Image abilityImgae2;
    bool isCoolDown2 = false;
    [Header("C")]
    public Image abilityImgae3;
    bool isCoolDown3 = false;
    [Header("SpcMar")]
    public Image abilityImgaeSpM;
    bool isCoolDownSpcM = false;
    [Header("ZMar")]
    public Image abilityImgae1M;
    bool isCoolDownM = false;
    [Header("XMar")]
    public Image abilityImgae2M;
    bool isCoolDown2M = false;
    public void Start()
    {
        abilityImgaeSp.fillAmount = 0;
        abilityImgae1.fillAmount = 0;
        abilityImgae2.fillAmount = 0;
        abilityImgae3.fillAmount = 0;
        abilityImgaeSpM.fillAmount = 0;
        abilityImgae1M.fillAmount = 0;
        abilityImgae2M.fillAmount = 0;
    }

    public void Update()
    {
        SpaceAtk();
        zAbiliti();
        xAbiliti();
        cAbiliti();
        SpaceAtkM();
        zPowerM1();
        XpowerM2();
    }

    
    void SpaceAtk()
    {

        if (Input.GetKey(coldwn._ZPower) && isCoolDownSpcM == false)
        {
            isCoolDownSpcM = true;
            abilityImgaeSpM.fillAmount = 1;
        }

        if (isCoolDownSpcM)
        {
            abilityImgaeSpM.fillAmount -= 1 / coldwn._ZCoolDown * Time.deltaTime;

            if (abilityImgaeSpM.fillAmount <= 0)
            {
                abilityImgaeSpM.fillAmount = 0;
                isCoolDownSpcM = false;
            }
        }

    }
    
    void zAbiliti()
    {
        if (Input.GetKey(coldwn._ZPower) && isCoolDown == false)
        {
            isCoolDown = true;
            abilityImgae1.fillAmount = 1;
        }

        if (isCoolDown)
        {
            abilityImgae1.fillAmount -= 1 / coldwn._ZCoolDown * Time.deltaTime;

            if (abilityImgae1.fillAmount <= 0)
            {
                abilityImgae1.fillAmount = 0;
                isCoolDown = false;
            }
        }
    }

    void xAbiliti()
    {
        if (Input.GetKey(coldwn._XPower) && isCoolDown2 == false)
        {
            isCoolDown2 = true;
            abilityImgae2.fillAmount = 1;
        }

        if (isCoolDown2)
        {
            abilityImgae2.fillAmount -= 1 / coldwn._XCoolDown * Time.deltaTime;

            if (abilityImgae2.fillAmount <= 0)
            {
                abilityImgae2.fillAmount = 0;
                isCoolDown2 = false;
            }
        }
    }

    void cAbiliti()
    {
        if (Input.GetKey(coldwn._CPower) && isCoolDown3 == false)
        {
            isCoolDown3 = true;
            abilityImgae3.fillAmount = 1;
        }

        if (isCoolDown3)
        {
            abilityImgae3.fillAmount -= 1 / coldwn._ZCoolDown * Time.deltaTime;

            if (abilityImgae3.fillAmount <= 0)
            {
                abilityImgae3.fillAmount = 0;
                isCoolDown3 = false;
            }
        }
    }
    void SpaceAtkM()
    {

        if (Input.GetKey(coldwn._basicAtack) && isCoolDown == false)
        {
            isCoolDownSpc = true;
            abilityImgaeSp.fillAmount = 1;
        }

        if (isCoolDownSpc)
        {
            abilityImgaeSp.fillAmount -= 1 / coldwn._basicCoolDown * Time.deltaTime;

            if (abilityImgaeSp.fillAmount <= 0)
            {
                abilityImgaeSp.fillAmount = 0;
                isCoolDownSpc = false;
            }
        }

    }
    void zPowerM1()
    {

        if (Input.GetKey(coldwn._ZPower) && isCoolDownM == false)
        {
            isCoolDownM = true;
            abilityImgae1M.fillAmount = 1;
        }

        if (isCoolDownM)
        {
            abilityImgae1M.fillAmount -= 1 / coldwn._ZCoolDown * Time.deltaTime;

            if (abilityImgae1M.fillAmount <= 0)
            {
                abilityImgae1M.fillAmount = 0;
                isCoolDownM = false;
            }
        }

    }
    void XpowerM2()
    {
        if (Input.GetKey(coldwn._XPower) && isCoolDown2M == false)
        {
            isCoolDown2M = true;
            abilityImgae2M.fillAmount = 1;
        }

        if (isCoolDown2M)
        {
            abilityImgae2M.fillAmount -= 1 / coldwn._XCoolDown * Time.deltaTime;

            if (abilityImgae2M.fillAmount <= 0)
            {
                abilityImgae2M.fillAmount = 0;
                isCoolDown2M = false;
            }
        }
    }
}

