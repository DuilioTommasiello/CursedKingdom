using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownScripts : MonoBehaviour
{
     private Habilities coldwn;

    [Header("Z")]
    public Image abilityImgae1;
    bool isCoolDown = false;
    [Header("X")]
    public Image abilityImgae2;
    bool isCoolDown2 = false;
    [Header("C")]
    public Image abilityImgae3;
    bool isCoolDown3 = false;
    private void Start()
    {
        abilityImgae1.fillAmount = 0;
        abilityImgae2.fillAmount = 0;
        abilityImgae3.fillAmount = 0;
    }

    private void Update()
    {
        zAbiliti();
        xAbiliti();
        cAbiliti();
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
        if (Input.GetKey(coldwn._ZPower) && isCoolDown3 == false)
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
}
