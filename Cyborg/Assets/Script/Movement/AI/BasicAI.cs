using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : Attack {
   
    public override Vector2 move(Vector2 tan)
    {
        return getSpeed() * tan;
        
    }
    public override void updateSprites()
    {

    }

    public override void attack()
    {
        throw new NotImplementedException();
    }



}
