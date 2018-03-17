using UnityEngine;
using Projectile.ObjectPooling;

namespace Enemy
{
    public class ProjectileAI : Attack
    {
        /// <summary> The GameObject holding the bullet spawn point. </summary>
        public Transform weaponRotation;
        /// <summary> The point to spawn the bullets at. </summary>
        public Transform bulletSpawn;
        /// <summary> How often to shoot. </summary>
        public float shootTime;
        public Sprite[] spriteArray;

        //tests the possible gameobject targets for projectile
        private Transform[] possibleProjectilePos;
        private SpriteRenderer mySpriteRenderer;
        private GameObject player;
        /// <summary> Timer for tracking when to shoot. </summary>
        private float shootTimer;

        private void Start()
        {
            this.mySpriteRenderer = GetComponent<SpriteRenderer>();
            this.player = GameObject.Find("Player");
            this.possibleProjectilePos = player.GetComponentsInChildren<Transform>();
            this.shootTimer = this.shootTime;
        }

        public override Vector2 move(Vector2 tan)
        {
            SetSprite();
            PositionProjectileEnemy();
            if ((this.shootTimer -= Time.deltaTime) <= 0f)
            {
                FireBullet();
                this.shootTimer = this.shootTime;
            }

            return getSpeed() * tan;
        }

        public override void updateSprites()
        {
        }

        public override void attack()
        {
            FireBullet();
        }

        /// <summary> Thest the sprite based on aim direction. </summary>
        private void SetSprite()
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;
            float absx = Mathf.Abs(dirToPlayer.x);
            float absy = Mathf.Abs(dirToPlayer.y);
            if (absx >= absy)
            {
                this.mySpriteRenderer.sprite = spriteArray[0];
                if (-dirToPlayer.x == 1)
                    this.mySpriteRenderer.flipX = false;
                else
                    this.mySpriteRenderer.flipX = true;
            }
            else
            {
                this.mySpriteRenderer.flipX = false;
                if (-dirToPlayer.y == 1)
                    this.mySpriteRenderer.sprite = spriteArray[1];
                else
                    this.mySpriteRenderer.sprite = spriteArray[2];
            }
        }

        private void PositionProjectileEnemy()
        {
            float dist = 0;
            float maxdist = 0;

            Transform moveHere = player.transform;
            foreach (Transform pos in possibleProjectilePos)
            {
                dist = Vector3.Distance(transform.position, pos.position);
                if (dist > maxdist)
                {
                    moveHere = pos;
                }
            }

            changeTarget(moveHere);
        }

        /// <summary> Fires a bullet at the player. </summary>
        private void FireBullet()
        {
            Vector3 targetPos = player.transform.position;
            float angle = Vector2.SignedAngle(Vector2.right, (targetPos - this.transform.position).normalized);
            this.weaponRotation.rotation = Quaternion.Euler(0, 0, angle);
            GameObject b = BulletPool.Instance.GetBullet(BulletPool.BulletTypes.Enemy);
            if (b != null)
            {
                b.transform.position = this.bulletSpawn.position;
                b.transform.rotation = this.bulletSpawn.rotation;
            }
        }
    }
}


