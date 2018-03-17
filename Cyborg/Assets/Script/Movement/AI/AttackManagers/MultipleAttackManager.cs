using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Enemy
{
    public class MultipleAttackManager : AttackManager
    {
        private GameObject playerLocation;
        [HideInInspector]
        public Vector2 playerdir;
        [HideInInspector]
        public Direction facingdir;
        [HideInInspector]
        public enum Direction { up, down, left, right };

        //array of attacks to go through
        //public Attack[] attacks;

        //time to change attack
        private float changeTime;

        //whether to go on to next attack
        private bool changeAttack;
     
        //index of attacks to set currentAttack
        private int attackIndex;
        
        //attack currently running
        private Attack currentAttack;

        private int count;
        // Use this for initialization
        void Start()
        {
            changeAttack = false;
            attackIndex = 0;
            if (attacks.Length == 0)
            {
                Debug.Log("Cannot have no attacks.");
            }
            currentAttack = attacks[0];
            playerLocation = GameObject.Find("Player");
        }

        private void Update()
        {
            playerdir = dirToPlayer();
        }

        //called in FixedUpdate in AIPath
        public override Attack chooseAttack()
        {
            CheckAttackChange();
            if (changeAttack)
            {
                if (attackIndex == attacks.Length-1)
                {
                    attackIndex = 0;
                    Debug.Log("basic");
                } else
                {
                    attackIndex++;
                    Debug.Log("charge");
                }
                currentAttack = attacks[attackIndex];
                changeAttack = false;
                StartDelay();
               
            }
            return currentAttack;

        }


        private void StartDelay()
        {
            changeTime = Time.time + delay;
        }

        private void CheckAttackChange()
        {
            if (Time.time >= changeTime)
            {
                changeAttack = true;
            }
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
