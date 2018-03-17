using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Enemy
{
    public class SingleAttackManager : AttackManager
    {
        private GameObject playerLocation;
        [HideInInspector]
        public Vector2 playerdir;
        [HideInInspector]
        public Direction facingdir;
        [HideInInspector]
        public enum Direction { up, down, left, right };

        public override Attack chooseAttack()
        {
            return (Attack)gameObject.GetComponent<Attack>();
        }

        private void Start()
        {
            playerLocation = GameObject.Find("Player");
        }
        private void Update()
        {
            playerdir = dirToPlayer();
        }

        public override Vector2 dirToPlayer()
        {
            return playerLocation.transform.position - this.gameObject.transform.position;
        }

        public override void findFacing()
        {
            if (Math.Abs(playerdir.x) > Math.Abs(playerdir.y))
            {
                if (playerdir.x > 0)
                {
                    facingdir = Direction.right;
                }
                else
                {
                    facingdir = Direction.left;
                }
            }
            else
            {
                if (playerdir.y > 0)
                {
                    facingdir = Direction.up;
                }
                else
                {
                    facingdir = Direction.down;
                }
            }
        }
    }
}

    
