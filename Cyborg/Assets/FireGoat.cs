using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using System;
using Projectile.ObjectPooling;
using Projectile.ObjectPooling.Bullets;

public class FireGoat : Attack {
    public Transform rtLoc;
    public Transform ltLoc;
    public Transform tpLoc;
    public Transform bmLoc;

    public GoatDemonAttackManager.Direction dir;
    private bool allowAttack;
    private void Start()
    {
        allowAttack = true;
    } 

    public override Vector2 move(Vector2 tan)
    {
        Vector2 idle = new Vector2(0, 0);
        return idle;
    }

    public override void attack()
    {
        for(int i = 0; i < 5; i++)
        {
            CreateBullet();
        }
    }

    private void CreateBullet()
    {
        GameObject b = BulletPool.Instance.GetBullet(BulletPool.BulletTypes.Goat);
        if (b != null)
        {
            GoatBullet goatbullet = b.GetComponent<GoatBullet>();
            if (dir == GoatDemonAttackManager.Direction.right)
            {
                b.transform.position = rtLoc.position;
            }
            else if (dir == GoatDemonAttackManager.Direction.left)
            {
                b.transform.position = ltLoc.position;
            }
            else if (dir == GoatDemonAttackManager.Direction.down)
            {
                b.transform.position = bmLoc.position;
            }
            else if (dir == GoatDemonAttackManager.Direction.up)
            {
                b.transform.position = tpLoc.position;
            }

            goatbullet.ChooseSprite();
        }

    }

   

    public override void updateSprites()
    {

    }

}
