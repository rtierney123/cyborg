using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAttackManager : AttackManager {


    public override Attack chooseAttack()
    {
        return (Attack) gameObject.GetComponent<Attack>();
    }
}
