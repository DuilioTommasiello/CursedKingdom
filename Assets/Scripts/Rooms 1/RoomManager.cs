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
        CountEnemiesInRoom();
        destoyfogs();

        foreach (Collider2D collider in rooms)
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
    private void CountEnemiesInRoom()
    {

        Collider2D currentRoomCollider = null;

        foreach (Collider2D collider in rooms)
        {
            if (collider.bounds.Contains(player.transform.position))
            {
                currentRoomCollider = collider;
                break;
            }
        }

        if (currentRoomCollider != null)
        {
            int enemyCount = 0;

            Collider2D[] enemiesInRoom = Physics2D.OverlapCircleAll(currentRoomCollider.bounds.center, currentRoomCollider.bounds.size.x / 2f, 1 << 6);
            foreach (Collider2D enemyCollider in enemiesInRoom)
            {
                if (enemyCollider.gameObject.layer == 6)
                {
                    enemyCount++;
                }
            }

            EnemyOnRoom = enemyCount; 
        }
        else
        {
            EnemyOnRoom = 0; 
        }
    }
    
    void destoyfogs()
    {
        if(_whichRoom == 1 && EnemyOnRoom == 0 )
        {
            Destroy(Fogs[0]);
        }
        if (_whichRoom == 2 && EnemyOnRoom == 0)
        {
            Destroy(Fogs[1]);
            Destroy(Fogs[2]);
        }
        if (_whichRoom == 3 && EnemyOnRoom == 0)
        {
            Destroy(Fogs[2]);
            Destroy(Fogs[3]);
        }
        if (_whichRoom == 4 && EnemyOnRoom == 0)
        {
            Destroy(Fogs[3]);
            Destroy(Fogs[4]);
        }
        if (_whichRoom == 4 && EnemyOnRoom == 0)
        {
            Destroy(Fogs[4]);
            Destroy(Fogs[1]);
        }
    }
}
