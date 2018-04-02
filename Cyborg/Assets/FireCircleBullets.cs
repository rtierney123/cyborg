using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Projectile.ObjectPooling;

namespace Enemy {
    public class FireCircleBullets : Attack
    {
        public GameObject bulletLocations;
        private Transform[] locations;

        private void Start()
        {
            locations = bulletLocations.GetComponentsInChildren<Transform>();
        }
        public override Vector2 move(Vector2 tan)
        {
            setSpeed(15);
            return getSpeed() * tan;

        }
        public override void updateSprites()
        {

        }

        public override void attack()
        {
            foreach(Transform loc in locations)
            {
                GameObject b = BulletPool.Instance.GetBullet(BulletPool.BulletTypes.Circle);
                if (b != null)
                {
                    b.transform.position = loc.position;
                    b.transform.rotation = loc.rotation;
                }
            }
         
        }

   
    }
}

