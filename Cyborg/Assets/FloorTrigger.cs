using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Rooms
{
    public class FloorTrigger : MonoBehaviour
    {

        [HideInInspector]
        public bool inRoom;

        private void Start()
        {
            inRoom = false;
        }

        void OnTriggerEnter2D(Collider2D aCol)
        {
            if (aCol.gameObject.tag == "Player")
            {
                inRoom = true;
            }
        }
    }
}

