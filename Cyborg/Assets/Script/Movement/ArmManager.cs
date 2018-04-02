using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class ArmManager : Attack {
    public GameObject rtupperPivot;
    public GameObject rtlowerPivot;
    public GameObject rtClawRight;
    public GameObject rtClawLeft;

    public GameObject ltupperPivot;
    public GameObject ltlowerPivot;
    public GameObject ltClawRight;
    public GameObject ltClawLeft;

    public float clawTime;

    private void Start()
    {
      
    }

    public override Vector2 move(Vector2 tan)
    {
        return getSpeed() * tan;

    }
    public override void updateSprites()
    {

    }


    public override void attack()
    {

    }
}
