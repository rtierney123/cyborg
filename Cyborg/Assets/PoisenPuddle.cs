using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Projectile.ObjectPooling;

namespace Enemy
{
    public class PoisenPuddle : Attack
    {
        private bool canMakePuddle = true;
        private Vector2 travelDir;
        private bool allowChange;
        public Transform puddleLocation;
        private int yieldTime;

        private void Start()
        {
            travelDir = new Vector2(0, -1);
            allowChange = true;
            yieldTime = 5;
        }
        public override Vector2 move(Vector2 tan)
        {
            if (allowChange)
            {
                allowChange = false;
                Invoke("RandomDir", yieldTime);
                //yieldTime = 2;
            }
            return getSpeed() * travelDir;

        }
        public override void updateSprites()
        {

        }

        public override void attack()
        {
            if (canMakePuddle)
            {
                StartCoroutine(DelayCreatePuddle());
            }
        }

        IEnumerator DelayCreatePuddle()
        {
            stopPuddle();

            yield return 100000;

            makePuddle();
        }

        private void stopPuddle()
        {
            canMakePuddle = false;
        }

        private void makePuddle()
        {
            canMakePuddle = true;
            GameObject b = BulletPool.Instance.GetBullet(BulletPool.BulletTypes.Puddle);

            if (b != null)
            {
                b.transform.position = puddleLocation.position;
                b.transform.rotation = puddleLocation.rotation;
            }
        }

        private void LateUpdate()
        {
            attack();
        }

        private void RandomDir()
        {
            float xvalue = Random.value;
            float yvalue = Random.value;
            xvalue = MapValue(xvalue, 0, 1, -1, 1);
            yvalue = MapValue(yvalue, 0, 1, -1, 1);
            travelDir = new Vector2(xvalue, yvalue).normalized;
            allowChange = true;
        }

        private float MapValue(float value, float low1, float high1, float low2, float high2)
        {
            return (value - low1)/(high1 - low1) * (high2 - low2) +low2;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag != "Bullet")
            {
                travelDir = -travelDir;
                yieldTime = 5;
            }
            
        }
    }

}
