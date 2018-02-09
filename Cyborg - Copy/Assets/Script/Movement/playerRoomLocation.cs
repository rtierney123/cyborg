using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRoomLocation : MonoBehaviour {
    [HideInInspector]
    public int roomnum;
    private GameObject player;
    void Awake()
    {
        roomnum = 0;
        player = GameObject.Find("Player");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            roomnum++;
        }
    }

}
