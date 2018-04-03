using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Enemy
{
    public class FinalBossAttackManager : AttackManager {

        private GameObject playerLocation;
        [HideInInspector]
        public Vector2 playerdir;
        [HideInInspector]
        public Direction facingdir;
        [HideInInspector]
        public enum Direction { up, down, left, right };

        //time to change attack
        private float changeTime;
        //keeps track whether to change attack or not
        private bool changeAttack;
        //number to keep track of which attack
        private int attackCount;

        private BasicAI basic;
        private SwingArms swing;
        private FireCircleBullets fire;
        private Attack currentAttack;

        private enum AttackMode { swing, fire };
        private AttackMode currentMode;

        private int count;
        // Use this for initialization
        void Start()
        {
            changeAttack = false;
            attackCount = 1;
            currentAttack = swing;
            swing = gameObject.GetComponent<SwingArms>();
            fire = gameObject.GetComponent<FireCircleBullets>();
            basic = gameObject.GetComponent<BasicAI>();
            playerLocation = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            playerdir = dirToPlayer();
            if (currentMode == AttackMode.swing)
            {
                swing.attack();
            } 
        }

        public override Attack chooseAttack()
        {
            CheckAttackChange();
            if (changeAttack)
            {
                if (attackCount == 1)
                {
                    StartDelay();
                    currentAttack = swing;
                    changeAttack = false;
                    attackCount++;
                    currentMode = AttackMode.swing;
                    return swing;
                }
                else if (attackCount == 2)
                {
                    StartDelay();
                    currentAttack = fire;
                    fire.attack();
                    changeAttack = false;
                    attackCount=1;
                    currentMode = AttackMode.fire;
                    return swing;
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

