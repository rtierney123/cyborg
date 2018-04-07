using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Projectile.ObjectPooling.Bullets
{
    public class FireBall : Bullet
    {

        public float speed;
        public Rigidbody2D rgbdy;
        public bool hasRB;
    

        private Transform newFireLoc;
        private bool makeFireBall = true;

        private bool hitWall = false;

        private void Awake()
        {
            newFireLoc = gameObject.transform.GetChild(0).transform;
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
                this.rgbdy.velocity = this.transform.right * speed;
            }
        }

        private void OnEnable()
        {
            Invoke("MakeFireBall", 2);
        }

        private void MakeFireBall()
        {
            GameObject newFireBall = BulletPool.Instance.GetBullet(BulletPool.BulletTypes.FireBall);
            if (newFireBall != null && !hitWall)
            {
                newFireBall.transform.position = newFireLoc.position;
                newFireBall.transform.rotation = newFireLoc.rotation;
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //hitWall = true;
        }
    }
}
