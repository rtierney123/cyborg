using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAttackManager : AttackManager {

    void Start()
    {
        attacks = gameObject.GetComponents(typeof(Attack));
    }

    public override Attack chooseAttack()
    {
        if (attacks.Length == 0)
        {
            Debug.Log("Must have at least one attack.");
        }
        return (Attack) attacks[0];
    }
}
