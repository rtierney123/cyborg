using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAttackManager : AttackManager {


    public override Attack chooseAttack()
    {
        if (attacks == null)
        {
            Debug.Log("Must have at least one attack.");
        }
        return attacks[0];
    }
}
