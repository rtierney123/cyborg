using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using Projectile.ObjectPooling;

public class RayGunAI : Attack {

    public Transform rtFire;
    public Transform ltFire;
    public Transform tpFire;
    public Transform bmFire;
   
    /// <summary> The point to spawn the bullets at. </summary>
    private Transform bulletSpawn;
    /// <summary> How often to shoot. </summary>
    public float shootTime;
    public Sprite[] spriteArray;

    private enum Direction { right, left, up, down};
    private Direction direction;

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
        bulletSpawn = rtFire;
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
        Vector3 dirToPlayer = player.transform.position - transform.position;
        float absx = Mathf.Abs(dirToPlayer.x);
        float absy = Mathf.Abs(dirToPlayer.y);
        if (absx > absy)
        {
            this.mySpriteRenderer.sprite = spriteArray[0];
            if (dirToPlayer.x > 0)
            {
                this.mySpriteRenderer.flipX = false;
                direction = Direction.right;
            }
            else
            {
                this.mySpriteRenderer.flipX = true;
                direction = Direction.left;
            }
                
        }
        else
        {
            this.mySpriteRenderer.flipX = false;
            if (dirToPlayer.y > 0)
            {
                this.mySpriteRenderer.sprite = spriteArray[1];
                direction = Direction.up;
            }
                
            else
            {
                this.mySpriteRenderer.sprite = spriteArray[2];
                direction = Direction.down;
            }
                
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
        ChooseFirePos();
        GameObject b = BulletPool.Instance.GetBullet(BulletPool.BulletTypes.Blaster);
        if (b != null)
        {
            Debug.Log("fire");
            b.transform.position = this.bulletSpawn.position;
        }
  
    }

    private void ChooseFirePos()
    {
        if (direction == Direction.right)
        {
            bulletSpawn = rtFire;
        } else if (direction == Direction.left)
        {
            bulletSpawn = ltFire;
        } else if (direction == Direction.up)
        {
            bulletSpawn = tpFire;
        } else
        {
            bulletSpawn = bmFire;
        }
    }
}
