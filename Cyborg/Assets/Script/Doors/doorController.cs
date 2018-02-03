using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public int prevRoom;
    public int nextRoom;
    public GameObject player;
    public string enemyTag;

    private float xpos;
    private float ypos;

    void Start()
    {
        player = GameObject.Find("Player");
        xpos = this.gameObject.transform.position.x;
        ypos = this.gameObject.transform.position.y;
    }
    //player.GetComponent<playerRoomLocation>().roomnum> doorNum
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag(enemyTag) == null)
        {
            Destroy(this.gameObject);
        }
    }
}
