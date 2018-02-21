using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackManager : MonoBehaviour {
    
    //use as base for all boss attack managers
    protected Component[] attacks;
    //delay between attacks
    public int delay;

    //write script for how boss chooses next attack
    public abstract Attack chooseAttack();

}
