using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Rooms
{
    public class RoomManager : MonoBehaviour
    {

        //array of all doors to open and close based on if the room is cleared or full
        public Transform[] doors;
        //parent with enemy children
        public Transform enemiesParent;
        //gameobject that has collider trigger that starts enemies and closes doors when player in room
        public GameObject roomTrigger;
      

        //starts with false unil all enemies are killed
        private bool roomCleared;
        //keeps track if the player has entered the room for the first time
        private bool justEntered;
        //script with trigger bool
        private FloorTrigger trigger;
       
        private void Start()
        {
            if (enemiesParent.childCount != 0)
            {
                foreach (Transform door in doors)
                {
                    door.gameObject.SetActive(true);
                }
            }
            enemiesParent.gameObject.SetActive(false);

            roomCleared = false;
            justEntered = true;
          
            if (roomTrigger == null)
            {
                Debug.Log("Must have roomTrigger.");
            }
            trigger = roomTrigger.GetComponent<FloorTrigger>();
            if (trigger == null)
            {
                Debug.Log("Must have FloorTrigger on roomTrigger GameObject");
            }
            
       
        }

        // Update is called once per frame
        void Update()
        {
            
            if (trigger.inRoom && justEntered)
            {
                enemiesParent.gameObject.SetActive(true);
                foreach (Transform door in doors)
                {
                    door.gameObject.SetActive(true);
                }
                justEntered = false;
            } 
            
            if (enemiesParent.childCount == 0 && !roomCleared)
            {
                foreach (Transform door in doors)
                {
                    door.gameObject.SetActive(false);
                    roomCleared = true;
                }
            }
            
        }
    }



}
