using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Enemy
{
    public abstract class AttackManager : MonoBehaviour
    {
        //use as base for all boss attack managers
        public Attack[] attacks;
        //delay to switch between attacks
        public int delay;


        //write script for how boss chooses next attack
        public abstract Attack chooseAttack();

        //return vector for direction to player
        public abstract Vector2 dirToPlayer();

        //returns facing direction to player
        public abstract void findFacing();
       
    }
}


