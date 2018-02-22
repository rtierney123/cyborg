using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBearAttackManager : AttackManager {
    //time to change attack
    private float changeTime;
    //keeps track whether to change attack or not
    private bool changeAttack;
    //number to keep track of which attack
    private int attackCount;

    private TankChargeAttack charge;
    private BouncyProjectileAttack bouncy;
    private Attack currentAttack;

    private int count;
	// Use this for initialization
	void Start () {
        changeAttack = false;
        attackCount = 1;
        currentAttack = charge;
        charge = gameObject.GetComponent<TankChargeAttack>();
        bouncy = gameObject.GetComponent<BouncyProjectileAttack>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
    }

    public override Attack chooseAttack()
    {
        CheckAttackChange();
        if (changeAttack)
        {
            if (attackCount == 1)
            {
                //StartCoroutine(DelayNextAttack());
                StartDelay();
                currentAttack = charge;
                changeAttack = false;
                attackCount++;
                Debug.Log("charge");
                return charge;
            } 
            else
            {
                //StartCoroutine(DelayNextAttack());
                StartDelay();
                currentAttack = bouncy;
                changeAttack = false;
                attackCount = 1;
                count++;
                Debug.Log("bouncy");
                return bouncy;
            }
        }
        return currentAttack;
        
    }
    /*
    IEnumerator DelayNextAttack()
    {

        yield return delay;

        NextAttack();
    }

    public void NextAttack()
    {
        changeAttack = true;
    }
    */
   

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



}
