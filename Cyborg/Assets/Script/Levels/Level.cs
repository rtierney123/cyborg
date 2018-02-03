using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Level : MonoBehaviour
{
    protected Room[] rooms;

    // Use this for initialization
    public void RoomSetup()
    {
        rooms = transform.GetComponentsInChildren<Room>();

        foreach (Room room in rooms)
        {
            room.BoardSetup();
        }
    }
}
