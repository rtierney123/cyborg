using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectile.ObjectPooling.Bullets
{
    public class BlasterBullet : Bullet
    {

        public float speed;
        public Rigidbody2D rgbdy;
        public bool hasRB;
        public float trackDuration;

        private GameObject player;
        private Vector2 dirToPlayer;
        private bool continueTrack;
        private bool startTrack;
        private void Start()
        {
            player = GameObject.Find("Player");
        }

        private void OnEnable()
        {
            StartTrack();
        }

        protected override void LocalInitialize()
        {
        }

        protected override void LocalReInitialize()
        {
        }

        protected override void LocalUpdate()
        {

            if (hasRB)
            {
                if (continueTrack)
                {
                    if (startTrack)
                    {
                        Invoke("StopTrack", trackDuration);
                    }
                    dirToPlayer = (player.transform.position - this.transform.position).normalized;
                    startTrack = false;
                }
                this.rgbdy.velocity = dirToPlayer * speed;
            }

        }

        protected override void LocalDeallocate()
        {
            if (hasRB)
            {
                this.rgbdy.velocity = Vector3.zero;
            }

        }

        protected override void LocalDelete()
        {
        }

        public void StartTrack()
        {
            startTrack = true;
            continueTrack = true;
        }

        public void StopTrack()
        {
            continueTrack = false;
        }
    }
}

