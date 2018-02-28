using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour {
    private GameObject player;
    private playerMovement script;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        script = player.GetComponent<playerMovement>();
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Entering level.");
        if (coll.gameObject.tag == "Player")
        {
            script.onlyX = false;
        }
    }
}
