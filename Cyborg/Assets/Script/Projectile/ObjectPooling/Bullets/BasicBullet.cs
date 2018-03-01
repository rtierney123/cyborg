namespace Projectile.ObjectPooling.Bullets
{ 
    using UnityEngine;

    public class BasicBullet : Bullet
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
