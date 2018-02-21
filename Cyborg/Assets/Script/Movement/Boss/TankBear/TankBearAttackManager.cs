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

    public override void chooseAttack()
    {

    }

    IEnumerator StartAttack()
    {

        yield return 5;

        chooseAttack();
    }
}
