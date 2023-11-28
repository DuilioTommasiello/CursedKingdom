using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject player;
    private  int _whichRoom;
    private  int indice;
    [SerializeField] public new List<GameObject> Fogs = new List<GameObject>();
    [SerializeField] public new List<Collider2D> rooms = new List<Collider2D>();

    private void Update()
    {
        bool InsideARoom = false;

        foreach(Collider2D collider in rooms)
        {
            if(collider.bounds.Contains(player.transform.position))
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
        }
        
    }
}
