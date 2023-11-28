using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject player;
    public  int _whichRoom;
    public  int EnemyOnRoom;
    private  int _whichFog;
    private  int indice;
    [SerializeField] public new List<GameObject> Fogs = new List<GameObject>();
    [SerializeField] public new List<Collider2D> rooms = new List<Collider2D>();

    private void Awake()
    {
        Fogs[0].SetActive(false);
        Fogs[1].SetActive(false);
        Fogs[2].SetActive(false);
        Fogs[3].SetActive(false);
        Fogs[4].SetActive(false);
    }
    private void Update()
    {
        bool InsideARoom = false;

        foreach(Collider2D collider in rooms)
        {
            #region roomsIndex 
            if (collider.bounds.Contains(player.transform.position))
            {
                InsideARoom = true;

                if (collider == rooms[0])
                {
                    _whichRoom = 1;
                    break;
                }
                else if (collider == rooms[1])
                {
                    _whichRoom = 2;
                    break;
                }
                else if (collider == rooms[2])
                {
                    _whichRoom = 3;
                    break;
                }else if(collider == rooms[3])
                {
                    _whichRoom = 4;
                }else if (collider == rooms[4])
                {
                    _whichRoom = 5;
                }
            }
            if(!InsideARoom)
            {
                _whichRoom = 500;
            }
            #endregion

        }
        #region activador de fogs       
        switch (_whichRoom)
        {
            case 1:
                if (Fogs[0] != null)
                Fogs[0].SetActive(true);         
                
                break;
            case 2:
                if(Fogs[1] != null)
                Fogs[1].SetActive(true);

                if (Fogs[2] != null)
                Fogs[2].SetActive(true);

                if (Fogs[0] != null)
                Fogs[0].SetActive(true);
                                
             break;

            case 3:
                if (Fogs[2] != null)
                    Fogs[2].SetActive(true);

                if (Fogs[3] != null)
                    Fogs[3].SetActive(true);

                break;
            case 4:
                if (Fogs[3] != null)
                    Fogs[3].SetActive(true);

                if (Fogs[4] != null)
                    Fogs[4].SetActive(true);
                break;
            case 5:
                if (Fogs[1] != null)
                    Fogs[1].SetActive(true);

                if (Fogs[5] != null)
                    Fogs[5].SetActive(true);
                break;




            default:
                break;
        }
        #endregion
    }
}
