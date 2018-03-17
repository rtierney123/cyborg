using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Projectile.ObjectPooling;
namespace Enemy
{
    public class ShieldAI : Attack
    {
        private enum State { attacking, moving, charging };
        public enum Direction { up, down, left, right };
        private bool attacking;

        public Sprite[] spritesIdle;
        public Sprite[] spritesAttack;
        public SpriteRenderer spriteRenderer;
        public Sprite[] shieldSprites;
        public SpriteRenderer shieldRenderer;
        public Transform projectileSpawner;

        public float chargeTime;
        public float range;
        public int speed;
        public int shotSpread;

        private GameObject target;
        private State state;
        private Direction dir;
        private float startChargeTime;
        private Transform shield;
        private Transform upLoc;
        private Transform downLoc;
        private Transform rightLoc;
        private Transform leftLoc;
        private SpriteRenderer shieldSprite;

        public void Start()
        {
            state = State.moving;
            target = GameObject.Find("Player");
            attacking = false;
            shield = transform.GetChild(0);
            shieldSprite = shield.GetComponent<SpriteRenderer>();
            upLoc = transform.GetChild(1);
            downLoc = transform.GetChild(2);
            rightLoc = transform.GetChild(3);
            leftLoc = transform.GetChild(4);
        }

        public override Vector2 move(Vector2 tan)
        {
            setSpeed(speed);
            if (Math.Abs(tan.x) > Math.Abs(tan.y))
            {
                if (tan.x > 0)
                {
                    dir = Direction.right;
                    shield.position = rightLoc.position;
                    shieldSprite.sortingLayerName = spriteRenderer.sortingLayerName;
                }
                else
                {
                    dir = Direction.left;
                    shield.position = leftLoc.position;
                    shieldSprite.sortingLayerName = spriteRenderer.sortingLayerName;
                }
            }
            else
            {
                if (tan.y > 0)
                {
                    dir = Direction.up;
                    shield.position = upLoc.position;
                    shieldSprite.sortingLayerName = "wall";
                }
                else
                {
                    dir = Direction.down;
                    shield.position = downLoc.position;
                    shieldSprite.sortingLayerName = spriteRenderer.sortingLayerName;
                }
            }
            UpdateState();
            if (state == State.charging || state == State.attacking)
            {
                return new Vector2();
            }
            else
            {
                return getSpeed() * tan;
            }

        }

        public override void updateSprites()
        {
            switch (dir)
            {
                case Direction.up:
                    if (state == State.attacking)
                    {
                        shieldRenderer.enabled = false;
                        spriteRenderer.sprite = spritesAttack[0];
                        shieldRenderer.sprite = shieldSprites[0];
                    }
                    else if (state == State.moving)
                    {
                        shieldRenderer.enabled = true;
                        spriteRenderer.sprite = spritesIdle[0];
                        shieldRenderer.sprite = shieldSprites[0];
                    }
                    else if (state == State.charging)
                    {
                        shieldRenderer.enabled = false;
                        spriteRenderer.sprite = spritesAttack[0];
                        shieldRenderer.sprite = shieldSprites[0];
                    }
                    break;
                case Direction.right:
                    if (state == State.attacking)
                    {
                        shieldRenderer.enabled = false;
                        spriteRenderer.sprite = spritesAttack[1];
                        shieldRenderer.sprite = shieldSprites[1];
                        spriteRenderer.flipX = false;
                    }
                    else if (state == State.moving)
                    {
                        shieldRenderer.enabled = true;
                        spriteRenderer.sprite = spritesIdle[1];
                        shieldRenderer.sprite = shieldSprites[1];
                        spriteRenderer.flipX = false;
                    }
                    else if (state == State.charging)
                    {
                        shieldRenderer.enabled = false;
                        spriteRenderer.sprite = spritesAttack[1];
                        shieldRenderer.sprite = shieldSprites[1];
                        spriteRenderer.flipX = false;
                    }
                    break;
                case Direction.down:
                    if (state == State.attacking)
                    {
                        shieldRenderer.enabled = false;
                        spriteRenderer.sprite = spritesAttack[2];
                        shieldRenderer.sprite = shieldSprites[0];
                    }
                    else if (state == State.moving)
                    {
                        shieldRenderer.enabled = true;
                        spriteRenderer.sprite = spritesIdle[2];
                        shieldRenderer.sprite = shieldSprites[0];
                    }
                    else if (state == State.charging)
                    {
                        shieldRenderer.enabled = false;
                        spriteRenderer.sprite = spritesAttack[2];
                        shieldRenderer.sprite = shieldSprites[0];
                    }
                    break;
                case Direction.left:
                    if (state == State.attacking)
                    {
                        shieldRenderer.enabled = false;
                        spriteRenderer.sprite = spritesAttack[1];
                        shieldRenderer.sprite = shieldSprites[1];
                        spriteRenderer.flipX = true;
                    }
                    else if (state == State.moving)
                    {
                        shieldRenderer.enabled = true;
                        spriteRenderer.sprite = spritesIdle[1];
                        shieldRenderer.sprite = shieldSprites[1];
                        spriteRenderer.flipX = true;
                    }
                    else if (state == State.charging)
                    {
                        shieldRenderer.enabled = false;
                        spriteRenderer.sprite = spritesAttack[1];
                        shieldRenderer.sprite = shieldSprites[1];
                        spriteRenderer.flipX = true;
                    }
                    break;
            }
        }

        public override void attack()
        {
            //Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, degree) * Vector2.right);
            /*
            Vector3 towardTarget = (target.transform.position - projectileSpawner.position).normalized;
            float angle = Vector3.Angle(Vector3.right, towardTarget);
            if (towardTarget.y < 0) {
                 angle = -angle;
            }
            */
            float angle;
            if (dir == Direction.up)
            {
                angle = 90;
            }
            else if (dir == Direction.down)
            {
                angle = 270;
            }
            else if (dir == Direction.right)
            {
                angle = 0;
            }
            else
            {
                angle = 180;
            }

            for (int i = -shotSpread; i <= shotSpread; i += shotSpread)
            {
                GameObject a = BulletPool.Instance.GetBullet(BulletPool.BulletTypes.Enemy);
                if (a != null)
                {
                    Vector3 sp = 3 * (Vector3)(Quaternion.Euler(0, 0, angle + i) * Vector3.right);
                    a.transform.position = projectileSpawner.position + sp;
                    a.transform.rotation = Quaternion.Euler(0, 0, angle + i);
                }
            }

        }

        private void UpdateState()
        {
            if (state == State.moving)
            {
                if ((transform.position - target.transform.position).magnitude <= range)
                {
                    startChargeTime = Time.time;
                    state = State.charging;
                }
            }
            else if (state == State.charging)
            {
                if ((transform.position - target.transform.position).magnitude > range * 1.5)
                {
                    state = State.moving;
                }
                else if (Time.time > startChargeTime + chargeTime)
                {
                    state = State.attacking;
                }
            }
            else if (state == State.attacking)
            {
                if (attacking == false)
                {
                    attack();
                    attacking = true;
                    Invoke("EndAttack", 1);
                }
            }
        }

        private void EndAttack()
        {
            attacking = false;
            state = State.moving;
        }



    }
}
