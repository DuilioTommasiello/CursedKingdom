using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : movement
{
    public GameObject player;
    [SerializeField] private  int _whichRoom;
    [SerializeField] public new List<GameObject> Fogs = new List<GameObject>();
    [SerializeField] public new List<Collider2D> rooms = new List<Collider2D>();


    private void Update()
    {
        Debug.Log(_whichRoom);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        //if()
        //{
        //    var b = rooms.Count;
        //    _whichRoom = b;

        //}






        //colitionComparer2(collision);
        //Debug.Log("estamos en la capa" + _whichRoom);
    }

    void colitionComparer2(Collider2D collision)
    {
        int index = rooms.IndexOf(collision);
        _whichRoom = index;
    }
    void romxd()
    {
        
    }
}
