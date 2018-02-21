using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankChargeAttack : Attack {
    private Vector2 currentPos;
    private Vector2 targetPos;
    private Vector2 dirToTarget;

    public override Vector2 move(Vector2 tan)
    {
        dirToTarget = (targetPos - currentPos).normalized;
        return getSpeed()*dirToTarget;

    }

    public override void updateSprites()
    {

    }

    public override void attack()
    {

    }

}
