using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class BackOff : Attack
    {
        public AttackManager attackManager;

        public override Vector2 move(Vector2 tan)
        {
            setSpeed(15);
            return -getSpeed() * attackManager.dirToPlayer();

        }
        public override void updateSprites()
        {

        }

        public override void attack()
        {

        }

    }
}

