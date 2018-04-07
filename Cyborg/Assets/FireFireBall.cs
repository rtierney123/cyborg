using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using Projectile.ObjectPooling;
using Projectile.ObjectPooling.Bullets;

public class FireFireBall : Attack {
    public Transform rtLoc;
    public Transform ltLoc;
    public Transform tpLoc;
    public Transform bmLoc;
    
    public SingleAttackManager.Direction dir;
    private bool allowAttack;

    private SingleAttackManager manager;
    private void Start()
    {
        allowAttack = true;
        manager = this.GetComponent<SingleAttackManager>();
    }

    private void Update()
    {
        attack();
        dir = manager.facingdir;
    }

    public override Vector2 move(Vector2 tan)
    {
        Vector2 idle = new Vector2(0, 0);
        return idle;
    }

    public override void attack()
    {
        if (allowAttack)
        {
            allowAttack = false;
            Invoke("CreateBullet", 5);
        }
    }

    private void CreateBullet()
    {
        manager.findFacing();
        allowAttack = true;
        Debug.Log(dir);
        GameObject b = BulletPool.Instance.GetBullet(BulletPool.BulletTypes.FireBall);
        if (b != null)
        {
            if (dir == SingleAttackManager.Direction.right)
            {
                b.transform.position = rtLoc.position;
                b.transform.rotation = rtLoc.rotation;
            }
            else if (dir == SingleAttackManager.Direction.left)
            {
                b.transform.position = ltLoc.position;
                b.transform.rotation = ltLoc.rotation;
            }
            else if (dir == SingleAttackManager.Direction.down)
            {
                b.transform.position = bmLoc.position;
                b.transform.rotation = bmLoc.rotation;
            }
            else if (dir == SingleAttackManager.Direction.up)
            {
                b.transform.position = tpLoc.position;
                b.transform.rotation = tpLoc.rotation;
            }

        }

    }



    public override void updateSprites()
    {

    }
}
