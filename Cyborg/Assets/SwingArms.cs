using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class SwingArms : ArmManager {
    bool restartClaw;
    bool restartUpper;
    bool restartLower;
    float clawStartTime;
    float clawShutTime;
    float clawEndTime;
    private enum ClawMode { open, shut};
    private ClawMode currentClaw;
    private enum UpperMode { open, shut };
    private UpperMode currentUpper;
    private enum LowerMode { open, shut };
    private LowerMode currentLower;
    private void Start()
    {
        restartClaw = true;
        restartUpper = true;
        restartLower = true;
        currentClaw = ClawMode.shut;
        currentUpper = UpperMode.shut;
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
        MoveClaws();
        MoveUpper();
        MoveLower();
    }

    private void MoveLower()
    {
        if (restartLower)
        {
            restartLower = false;
            rtlowerPivot.transform.Rotate(0, 0, 359);
            ltlowerPivot.transform.Rotate(0, 0, 359);
        }

        if (currentLower == LowerMode.shut)
        {
            if (rtlowerPivot.transform.localEulerAngles.z >= 340 || (rtlowerPivot.transform.localEulerAngles.z < 151 && rtlowerPivot.transform.localEulerAngles.z > 0))
            {
                rtlowerPivot.transform.Rotate(0, 0, -20 * Time.deltaTime);
                ltlowerPivot.transform.Rotate(0, 0, 20 * Time.deltaTime);

            }
            else
            {
                currentLower = LowerMode.open;
            }
        }
        else if (currentLower == LowerMode.open)
        {
            if (rtlowerPivot.transform.localEulerAngles.z > 339 || (rtlowerPivot.transform.localEulerAngles.z < 150 && rtlowerPivot.transform.localEulerAngles.z > 0))
            {
                rtlowerPivot.transform.Rotate(0, 0, 20 * Time.deltaTime);
                ltlowerPivot.transform.Rotate(0, 0, -20 * Time.deltaTime);
            }
            else
            {
                currentLower = LowerMode.shut;
            }
        }
    }

    private void MoveUpper()
    {
        if (restartUpper)
        {
            restartUpper = false;
            rtupperPivot.transform.Rotate(0, 0, 359);
            ltupperPivot.transform.Rotate(0, 0, 359);
        }

        if (currentUpper == UpperMode.shut)
        {
            if (rtupperPivot.transform.localEulerAngles.z >= 340 || (rtupperPivot.transform.localEulerAngles.z < 61 && rtupperPivot.transform.localEulerAngles.z > 0))
            {
                rtupperPivot.transform.Rotate(0, 0, -20 * Time.deltaTime);
                ltupperPivot.transform.Rotate(0, 0, 20 * Time.deltaTime);
            
            }
            else
            {
                currentUpper = UpperMode.open;
            }
        }
        else if (currentUpper == UpperMode.open)
        {
            if (rtupperPivot.transform.localEulerAngles.z > 239 || (rtupperPivot.transform.localEulerAngles.z < 60 && rtupperPivot.transform.localEulerAngles.z > 0))
            {
                rtupperPivot.transform.Rotate(0, 0, 20 * Time.deltaTime);
                ltupperPivot.transform.Rotate(0, 0, -20 * Time.deltaTime);
            }
            else
            {
                currentUpper = UpperMode.shut;
            }
        }
    }

    private void MoveClaws()
    {
        if (restartClaw)
        {
            clawStartTime = Time.time;
            clawShutTime = clawStartTime + (clawTime / 2);
            clawEndTime = clawStartTime + clawTime;
            restartClaw = false;
            rtClawRight.transform.Rotate(0, 0, 359);
            ltClawRight.transform.Rotate(0, 0, 359);
            rtClawLeft.transform.Rotate(0, 0, 359);
            ltClawLeft.transform.Rotate(0, 0, 359);
        }
        
        if (currentClaw == ClawMode.shut)
        {
            if (rtClawRight.transform.localEulerAngles.z >= 340)
            {
                rtClawRight.transform.Rotate(0, 0, -20 * Time.deltaTime);
                ltClawRight.transform.Rotate(0, 0, -20 * Time.deltaTime);
                rtClawLeft.transform.Rotate(0, 0, 20 * Time.deltaTime);
                ltClawLeft.transform.Rotate(0, 0, 20 * Time.deltaTime);
            }
            else
            {
                currentClaw = ClawMode.open;
            }
        }
        else if (currentClaw == ClawMode.open)
        {
            if (rtClawRight.transform.localEulerAngles.z > 1)
            {
                rtClawRight.transform.Rotate(0, 0, 20 * Time.deltaTime);
                ltClawRight.transform.Rotate(0, 0, 20 * Time.deltaTime);
                rtClawLeft.transform.Rotate(0, 0, -20 * Time.deltaTime);
                ltClawLeft.transform.Rotate(0, 0, -20 * Time.deltaTime);
            }
            else
            {
                rtClawRight.transform.Rotate(0, 0, 359);
                ltClawRight.transform.Rotate(0, 0, 359);
                rtClawLeft.transform.Rotate(0, 0, 359);
                ltClawLeft.transform.Rotate(0, 0, 359);
                currentClaw = ClawMode.shut;
            }
        }
    } 
    
}
