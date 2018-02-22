using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorClose : MonoBehaviour {

    public Transform previousRoom;

    private Transform doorsParent;

    void Awake()
    {
        doorsParent = previousRoom.transform.Find("Layout/Doors");
        if (doorsParent == null) {
            Debug.LogError("Could not find path Layout/Doors in " + previousRoom.name + " object.");
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
   
        if (col.gameObject.name == "Player")
        {
            doorsParent.gameObject.SetActive(true);
        }
    }
}
