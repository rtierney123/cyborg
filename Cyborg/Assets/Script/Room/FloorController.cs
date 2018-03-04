using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Rooms
{
    public class FloorController : MonoBehaviour
    {
        private Transform parent;
        private Transform enemies;

        private void Start()
        {
           
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                enemies.gameObject.SetActive(true);
            }
        }

        public void OnChildTriggerEnter(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                enemies.gameObject.SetActive(true);
            }
        }


    }
}

