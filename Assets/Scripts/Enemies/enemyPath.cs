using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPath : MonoBehaviour
{
    public CharacterChase ChSp;
    public SwitchCharacter swNum;
    public EyeShot shot;
    private enemyPath enmySC;
    public GameObject ferrana;
    public GameObject markus;

    [Header("chase values")]
    public float chasedistance = 10f;
    public float playerDistance;


    [SerializeField] List<Transform> wayPoints;
    public int Speed = 2;
    int nextPos = 0;

    private void Awake()
    {
        enmySC = GetComponent<enemyPath>();
        ChSp = GetComponent<CharacterChase>();
        shot = GetComponent<EyeShot>();
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
        }else
        {
            ChSp.enabled = true;
            shot.enabled = true;
            enmySC.enabled = false;
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
