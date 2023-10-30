
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPath : MonoBehaviour
{
    public EyeChase EyeSP;
    public SwitchCharacter swNum;
    private enemyPath enmySC;
    public GameObject ferrana;
    public GameObject markus;

    [Header("chase values")]
    public float chasedistance = 10f;
    public float playerDistance;


    [SerializeField] List<Transform> wayPoints;
    public int Speed = 2;
    public bool NeedShot;
    int nextPos = 0;

    private void Awake()
    {
        enmySC = GetComponent<enemyPath>();
        EyeSP = GetComponent<EyeChase>();

    }

    void Update()
    {
        // esto calcula la distancia para cada personaje 
        if (swNum.FeranaIsPLaying == true)
        {

            playerDistance = Vector2.Distance(transform.position, ferrana.transform.position);
            
        }else
        {
            playerDistance = Vector2.Distance(transform.position, markus.transform.position);

        }


        if (playerDistance > chasedistance )
        {
            patroll();
            NeedShot = false;
        }else
        {
            EyeSP.enabled = true;
            enmySC.enabled = false;
            NeedShot = true;
        }
    }

    void patroll()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[nextPos].transform.position, Speed * Time.deltaTime);

        if (transform.position == wayPoints[nextPos].transform.position)
        {
            nextPos++;
            if (nextPos >= wayPoints.Count) nextPos = 0;
        }
    }



}
