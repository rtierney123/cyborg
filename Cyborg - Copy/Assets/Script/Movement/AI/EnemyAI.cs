using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour {
    //this class gets the tangent of the path from A*
    //use this as base for all ememy movement scripts
    
    public abstract Vector2 move(Vector2 tan);

    public abstract void updateSprites();

    public float getSpeed()
    {
        return GetComponent<AIPath>().speed;
    }

    public void setSpeed(float newSpeed)
    {
        AIPath ai = GetComponent<AIPath>();
        ai.speed = newSpeed;
    }

    public void changeTarget(Transform newTarget)
    {
        AIPath ai = GetComponent<AIPath>();
        ai.updateTarget(newTarget);
    }
}
