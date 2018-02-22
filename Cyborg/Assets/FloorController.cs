using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {
    private Transform parent;
    private Transform enemies;

    private void Start()
    {
        parent = gameObject.transform.parent;
        enemies = parent.Find("Enemies");
        if (enemies == null)
        {
            Debug.LogError("Could not find path Enemies in " + transform.name + " object.");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemies.gameObject.SetActive(true);
        }
        /*
        if (other.gameObject.tag == "Player" && !playerInRoom)
        {
            playerInRoom = true;
            Debug.Log("Entering " + transform.name);
            enemiesParent.gameObject.SetActive(true);
            ClosePreviousRoomDoors();               
        }
        */
    }
}
