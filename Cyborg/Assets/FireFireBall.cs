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
    public AudioSource source;

    [HideInInspector]
    public SingleAttackManager.Direction dir;
    private bool allowAttack;

    private Transform[] possibleProjectilePos;
    private GameObject player;
    private SingleAttackManager manager;

    private void Awake()
    {
        allowAttack = true;
        manager = this.GetComponent<SingleAttackManager>();
        manager.findFacing();
        dir = manager.facingdir;
    }

    private void Start()
    {
        this.player = GameObject.Find("Player");
        this.possibleProjectilePos = player.GetComponentsInChildren<Transform>();
    }

    private void LateUpdate()
    {
        attack();
       
    }

    public override Vector2 move(Vector2 tan)
    {
        PositionEnemy();
        return getSpeed() * tan;
    }

    public override void attack()
    {
        if (allowAttack)
        {
            allowAttack = false;
            //Invoke("CreateBullet", 1);
            StartCoroutine(ExecuteAfterTime((float)2));
        }
    }

    private IEnumerator ExecuteAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        source.Play();
        CreateBullet();
    }

    private void CreateBullet()
    {
        manager.findFacing();
        dir = manager.facingdir;
        GameObject b = BulletPool.Instance.GetBullet(BulletPool.BulletTypes.FireBall);
        if (b != null)
        {
            //b.GetComponent<FireBall>().enemy = this.gameObject.transform;
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
                b.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (dir == SingleAttackManager.Direction.up)
            {
                b.transform.position = tpLoc.position;
                b.transform.rotation = tpLoc.rotation;
            }
            allowAttack = true;
        }
        

    }



    public override void updateSprites()
    {

    }

    private void PositionEnemy()
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
