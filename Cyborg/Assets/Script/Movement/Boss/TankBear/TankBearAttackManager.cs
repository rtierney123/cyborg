using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Enemy
{
    public class TankBearAttackManager : AttackManager
    {
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

        private TankChargeAttack charge;
        private TankDoubleCannon cannon;
        private BasicAI moveTowards;
        private BackOff backOff;
        private Attack currentAttack;
        private AudioSource audio;
        private int count;
        // Use this for initialization
        void Start()
        {
            changeAttack = false;
            attackCount = 1;
            currentAttack = charge;
            charge = gameObject.GetComponent<TankChargeAttack>();
            //cannon = gameObject.GetComponent<TankDoubleCannon>();
            moveTowards = gameObject.GetComponent<BasicAI>();
            backOff = gameObject.GetComponent<BackOff>();

            playerLocation = GameObject.Find("Player");
            audio = this.GetComponent<AudioSource>();
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
                    StartDelay();
                    currentAttack = moveTowards;
                    changeAttack = false;
                    attackCount++;
                    return moveTowards;
                }
                else if (attackCount == 2)
                {
                    delay = 5;
                    StartDelay();
                    currentAttack = charge;
                    changeAttack = false;
                    attackCount--;
                    audio.Play();
                    return charge;
                } else
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
        /*
        void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject healthBar = GameObject.Find("HealthBar");
            if (collision.gameObject.tag == "Enemy" && healthBar.transform.childCount != 0 && canTakeDamage)
            {
                healthBar.GetComponent<HealthBarUI>().RemoveLife();
                this.spriteFlasher.StartFlash();
                StartCoroutine(damageTimer());
                sfx.PlayPlayerHit();
            }
        }
        */
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Player")
            {
                currentAttack = backOff;
                attackCount = 3;
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

