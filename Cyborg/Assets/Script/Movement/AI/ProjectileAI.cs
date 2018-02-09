using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAI : EnemyAI{
    public Sprite[] spriteArray;
    //
    [HideInInspector]
    public Vector2 projectileDir;
    public string direction;
    //tests the possible gameobject targets for projectile
    private Transform[] possibleProjectilePos;
    private SpriteRenderer mySpriteRenderer;
    private GameObject player;
    

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        possibleProjectilePos = player.GetComponentsInChildren<Transform>();
    }


    public override Vector2 move(Vector2 tan)
    {
        Vector3 targetPosition = player.transform.position;
        Vector3 currentPosition = transform.position;
        Vector3 dirToPlayer = currentPosition - targetPosition;
        
        float absx = Mathf.Abs(dirToPlayer.x);
        float absy = Mathf.Abs(dirToPlayer.y);
        float x = dirToPlayer.x;
        float y = dirToPlayer.y;

        projectileDir = new Vector2();



        if (absx >= absy)
        {
            projectileDir = new Vector2(-dirToPlayer.x, 0);
            projectileDir = projectileDir.normalized;

            if (projectileDir.x == 1)
            {
                direction = "rt";
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = spriteArray[0];
                PositionProjectileEnemy();
            }
            else
            {
                direction = "lt";
                mySpriteRenderer.flipX = true;
                mySpriteRenderer.sprite = spriteArray[0];
                PositionProjectileEnemy();
            }


        }
        else
        {
            projectileDir = new Vector2(0, -dirToPlayer.y);
            projectileDir = projectileDir.normalized;

            if (projectileDir.y == 1)
            {
                direction = "tp";
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = spriteArray[1];
                PositionProjectileEnemy();
            }
            else
            {
                direction = "bm";
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = spriteArray[2];
                PositionProjectileEnemy();
            }

        }
        PositionProjectileEnemy();

        return getSpeed() * tan;

    }
    public override void updateSprites()
    {
       

    }

    void PositionProjectileEnemy()
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
}

