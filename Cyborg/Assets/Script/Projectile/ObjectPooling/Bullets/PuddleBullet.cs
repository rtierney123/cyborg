using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Projectile.ObjectPooling.Bullets
{
    public class PuddleBullet : Bullet
    {

        public float speed;
        public Rigidbody2D rgbdy;

        protected override void LocalInitialize()
        {
        }

        protected override void LocalReInitialize()
        {
        }

        protected override void LocalUpdate()
        {
            this.rgbdy.velocity = this.transform.right * speed;
        }

        protected override void LocalDeallocate()
        {
            this.rgbdy.velocity = Vector3.zero;
        }

        protected override void LocalDelete()
        {
        }
    }
}
