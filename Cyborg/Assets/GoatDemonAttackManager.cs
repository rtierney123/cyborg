using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Enemy
{
    public class GoatDemonAttackManager : AttackManager
    {

        private GameObject playerLocation;
        [HideInInspector]
        public Vector2 playerdir;
        [HideInInspector]
        public Direction facingdir;
        [HideInInspector]
        public enum Direction { up, down, left, right };
        [HideInInspector]
        public enum SpriteMode { idle, charging, fire};
        [HideInInspector]
        public SpriteMode currentMode;

        //time to change attack
        private float changeTime;
        //keeps track whether to change attack or not
        private bool changeAttack;
        //number to keep track of which attack
        private int attackCount;

        private TankChargeAttack charge;
        private BackOff backOff;
        private FireGoat fire;
        private Attack currentAttack;

        private int count;
        // Use this for initialization
        void Start()
        {
            changeAttack = false;
            attackCount = 1;
            currentAttack = charge;
            charge = gameObject.GetComponent<TankChargeAttack>();
            fire = gameObject.GetComponent<FireGoat>();
            backOff = gameObject.GetComponent<BackOff>();
            playerLocation = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            playerdir = dirToPlayer();
        }

        public override Attack chooseAttack()
        {
            CheckAttackChange();
            if (changeAttack)
            {
                if (attackCount == 1)
                {
                    currentMode = SpriteMode.charging;
                    StartDelay();
                    currentAttack = charge;
                    changeAttack = false;
                    attackCount++;
                    return charge;
                }
                else if (attackCount == 2)
                {
                    currentMode = SpriteMode.fire;
                    StartDelay();
                    currentAttack = fire;
                    changeAttack = false;
                    attackCount = 1;
                    return fire;
                }
                else
                {
                    StartDelay();
                    currentAttack = backOff;
                    changeAttack = false;
                    attackCount = 1;
                    return backOff;
                }
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

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Player")
            {
                currentAttack = backOff;
                currentMode = SpriteMode.idle;
                attackCount = 2;
                Debug.Log("backOff");
            }
        }

        public override Vector2 dirToPlayer()
        {
            return (playerLocation.transform.position - this.gameObject.transform.position).normalized;
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

