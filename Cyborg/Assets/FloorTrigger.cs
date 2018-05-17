using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Rooms
{
    public class FloorTrigger : MonoBehaviour
    {

        [HideInInspector]
        public bool inRoom;
        public AudioSource source;
        private bool playShut;
        public bool dontallowPlay;
        private void Start()
        {
            inRoom = false;
            playShut = true;
        }

        void OnTriggerEnter2D(Collider2D aCol)
        {
            if (aCol.gameObject.tag == "Player")
            {
                inRoom = true;
                if (playShut)
                {
                    if (!dontallowPlay)
                    {
                        source.Play();
                        playShut = false;
                    }
                    
                }
                
            }
        }
    }
}

