using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
namespace Projectile.ObjectPooling.Bullets
{
    public class GoatBullet : Bullet
    {
        public float speed;
        public Rigidbody2D rgbdy;
        public bool hasRB;

        private Transform player;
        private Vector2 playerLoc;
        private Vector2 bulletLoc;
        private Vector2 dirToTarget;

        private float targetDistance;
        private float currentDistance;

        private SpriteRenderer mySpriteRenderer;

        private GoatDemonAttackManager.Direction direction;
        public Sprite down;
        public Sprite up;
        public Sprite right;

        private UpdateColliders updateCol;
        private GameObject onCol;
        

        private void Start()
        {
            player = GameObject.Find("Player").transform;
            playerLoc = player.position;
            bulletLoc = gameObject.transform.position;
            dirToTarget = playerLoc - bulletLoc;
            targetDistance = dirToTarget.magnitude;

            mySpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            updateCol = this.GetComponent<UpdateColliders>();
            onCol = updateCol.bmCol;
            ChooseSprite();
        }

      

        public void ChooseSprite()
        {
            player = GameObject.Find("Player").transform;
            mySpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            updateCol = this.GetComponent<UpdateColliders>();

            playerLoc = player.position;
            bulletLoc = this.gameObject.transform.position;
            dirToTarget = playerLoc - bulletLoc;

            onCol = updateCol.bmCol;

            float absx = Mathf.Abs(dirToTarget.x);
            float absy = Mathf.Abs(dirToTarget.y);
            float x = dirToTarget.x;
            float y = dirToTarget.y;

            if (absx > absy)
            {
                if (x > 0)
                {
                    mySpriteRenderer.flipX = false;
                    mySpriteRenderer.sprite = right;


                    onCol.SetActive(false);
                    onCol = updateCol.rtCol;
                    onCol.SetActive(true);
                }
                else
                {
                    mySpriteRenderer.flipX = true;
                    mySpriteRenderer.sprite = right;

                    onCol.SetActive(false);
                    onCol = updateCol.ltCol;
                    onCol.SetActive(true);
                }
            }
            else
            {
                if (y > 0)
                {
                    mySpriteRenderer.sprite = up;

                    onCol.SetActive(false);
                    onCol = updateCol.tpCol;
                    onCol.SetActive(true);
                }
                else
                {
                    mySpriteRenderer.sprite = down;

                    onCol.SetActive(false);
                    onCol = updateCol.bmCol;
                    onCol.SetActive(true);
                }
            }
        }
        public void SetDirection(GoatDemonAttackManager.Direction dir)
        {
            direction = dir;
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
                this.rgbdy.velocity = dirToTarget.normalized * speed;
            }
            Vector2 currentPos = this.transform.position;
            currentDistance = (currentPos - bulletLoc).magnitude;
            if (currentDistance > targetDistance)
            {
                Explode();
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

        private void Explode()
        {
            
            GameObject b = BulletPool.Instance.GetBullet(BulletPool.BulletTypes.Puddle);
            if (b != null)
            {
                Debug.Log(b.name);
                b.transform.position = this.transform.position;
            }
            //Invoke("ReturnBullet", (float) .1);
            ReturnBullet();

        }

        protected override void OnCollisionEnter2D(Collision2D coll)
        {

            if (coll.gameObject.tag != "Enemy")
                //Invoke("Explode", (float).25);
                Explode();

        }

    }

}
