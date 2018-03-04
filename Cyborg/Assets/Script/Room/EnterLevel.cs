using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Rooms
{
    public class EnterLevel : MonoBehaviour
    {
        public Transform startDoor;

        private GameObject player;
        private playerMovement script;
        // Use this for initialization
        void Start()
        {
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
            startDoor.gameObject.SetActive(false);
        }
    }
}

