using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : EnemyAI {
   
    public override Vector2 move(Vector2 tan)
    {
        return getSpeed() * tan;
        
    }
    public override void updateSprites()
    {

    }


    
}
