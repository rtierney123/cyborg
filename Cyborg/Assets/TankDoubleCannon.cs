using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDoubleCannon : Attack {

    //length of charge
    public int delay;
    //time to fire
    private float fireTime;
    //keeps track whether to change attack or not
    private bool changeAttack;

 
    private void Start()
    {
      

    }

    public override Vector2 move(Vector2 tan)
    { 
        return getSpeed() * tan;
    }

    public override void updateSprites()
    {

    }

    public override void attack()
    {

    }

    private void StartDelay()
    {
        fireTime = Time.time + delay;
        changeAttack = false;
    }

    private void CheckCharge()
    {
        if (Time.time >= fireTime)
        {
            changeAttack = true;
        }
    }
}
