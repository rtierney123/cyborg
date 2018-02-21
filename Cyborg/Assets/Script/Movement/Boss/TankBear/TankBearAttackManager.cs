using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBearAttackManager : AttackManager {

	// Use this for initialization
	void Start () {
        StartCoroutine(StartAttack());
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        StartCoroutine(StartAttack());
    }

    public override Attack chooseAttack()
    {
        return new BasicAI();
    }

    IEnumerator StartAttack()
    {

        yield return 5;

        chooseAttack();
    }
}
