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

        [HideInInspector]
        //public Transform enemy;

        private Transform newFireLoc;
        private bool makeFireBall = true;

        private bool hitWall = false;
        private float allowNew;

        [HideInInspector]
        public bool createdByEnemy;
        private void Awake()
        {
            newFireLoc = gameObject.transform.GetChild(0).transform;
            allowNew = Time.time + 2;
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
            if (Time.time > allowNew)
            {
                StartCoroutine(AttackAfterTime((float).1));
            } else
            {
                ReturnBullet();
            }      
        }

        private IEnumerator AttackAfterTime(float delay)
        {
            yield return new WaitForSeconds(delay);
            MakeFireBall();
        }

        private void MakeFireBall()
        {
            
            GameObject newFireBall = BulletPool.Instance.GetBullet(BulletPool.BulletTypes.FireBall);
            if (newFireBall != null)
            {
                //newFireBall.GetComponent<FireBall>().enemy = this.enemy;
                newFireBall.transform.position = newFireLoc.position;
                newFireBall.transform.rotation = newFireLoc.rotation;
            }
            //Invoke("GetRidofFireBall", 1);
            StartCoroutine(ExecuteAfterTime(1));

        }
        private IEnumerator ExecuteAfterTime(float delay)
        {
            yield return new WaitForSeconds(delay);
            GetRidofFireBall();
        }

        private void GetRidofFireBall()
        {
            ReturnBullet();
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
        /*
        private void OnTriggerEnter2D(Collider2D collision)
        {
            ReturnBullet();

        }
        */
        
    }
}
