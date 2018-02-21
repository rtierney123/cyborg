using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyProjectileAttack : Attack {

    public override Vector2 move(Vector2 tan)
    {
        return new Vector2(0, 0);

    }

    public override void updateSprites()
    {

    }

    public override void attack()
    {
        CreateBouncyProjectile();
    }

    public void CreateBouncyProjectile()
    {

    }
}
