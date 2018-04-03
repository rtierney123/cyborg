using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class TankChargeAttack : Attack {
    //length of charge
    public int delay;
    //time to charge attack
    private float chargeTime;
    //keeps track whether to change attack or not
    private bool chargeAttack;

    private Vector2 currentPos;
    private Vector2 targetPos;
    private Vector2 dirToTarget;
    private GameObject player;

    private int count;
    private Rigidbody2D rb;
    private void Start()
    {
        player = GameObject.Find("Player");
        chargeAttack = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    public override Vector2 move(Vector2 tan)
    {
        setSpeed(30);
        CheckCharge();
        if (chargeAttack)
        {
            count++;
            StartDelay();
            currentPos = gameObject.transform.position;
            targetPos = player.transform.position;
            dirToTarget = (targetPos - currentPos).normalized;
        }
      
        return getSpeed()*dirToTarget;

    }

    public override void updateSprites()
    {

    }

    public override void attack()
    {

    }

    private void StartDelay()
    {
        chargeTime = Time.time + delay;
        chargeAttack = false;
    }

    private void CheckCharge()
    {
        if (Time.time >= chargeTime)
        {
            chargeAttack = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag == "CannotMove" || coll.gameObject.tag == "player")
        {
            //Debug.Log("hit wall");
            //dirToTarget = -dirToTarget;
            //chargeAttack = false;
        }
    }
}
