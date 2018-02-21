using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {
    public int roomnum;

    public Transform previousRoom;
    private Transform doorsPreviousParent;
    
    private Transform doorsParent;
    private Transform enemiesParent;
    private bool firstopen;
    private bool playerInRoom;
    void Awake()
    {
        playerInRoom = (roomnum == 1);

        doorsParent = transform.Find("Layout/Doors");
      
        if (doorsParent == null) {
            Debug.LogError("Could not find path Layout/Doors in " + transform.name + " object.");
        }

        enemiesParent = transform.Find("Enemies");
        if (enemiesParent == null) {
            Debug.LogError("Could not find path Enemies in " + transform.name + " object.");
        }

        if (!playerInRoom) {
            enemiesParent.gameObject.SetActive(false);
        }

        GetPreviousRoomDoors();
             
        firstopen = true;
    }
	// Update is called once per frame
	void Update () {
        if (enemiesParent.childCount==0)
        {
            if (firstopen)
            {
                doorsParent.gameObject.SetActive(false);
                firstopen = false;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !playerInRoom)
        {
            playerInRoom = true;
            Debug.Log("Entering " + transform.name);
            enemiesParent.gameObject.SetActive(true);
            ClosePreviousRoomDoors();               
        }
    }

    void GetPreviousRoomDoors() {
        if (previousRoom != null) {
            doorsPreviousParent = previousRoom.transform.Find("Layout/Doors");
            if (doorsPreviousParent == null) {
                Debug.LogError("Could not find path Layout/Doors in " + previousRoom.name + " object.");
            } 
        } else if (roomnum != 1){
            Debug.Log("Previous room reference not found, but current room not marked as first");
        }
    }

    void ClosePreviousRoomDoors() {
        if (doorsPreviousParent != null) {
            doorsPreviousParent.gameObject.SetActive(true);
        }
    }
}
