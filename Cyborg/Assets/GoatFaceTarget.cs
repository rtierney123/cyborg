using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class GoatFaceTarget : MonoBehaviour {

    public GameObject target;

    public Sprite downIdle;
    public Sprite upIdle;
    public Sprite rightIdle;

    public Sprite downCharge;
    public Sprite upCharge;
    public Sprite rightCharge;

    public Sprite downFire;
    public Sprite upFire;
    public Sprite rightFire;

    private SpriteRenderer mySpriteRenderer;
    private Vector2 currentPos;
    private Vector2 targetPos;
    private UpdateColliders updateCol;
    private GameObject onCol;

    private GoatDemonAttackManager manager;

    [HideInInspector]
    public Vector2 dirToTarget;

    // Use this for initialization
    void Start()
    {
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        updateCol = this.GetComponent<UpdateColliders>();
        onCol = updateCol.bmCol;
        manager = this.GetComponent<GoatDemonAttackManager>();
 

        //target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = target.GetComponent<Transform>().position;
        currentPos = this.transform.position;
        dirToTarget = targetPos - currentPos;

        float absx = Mathf.Abs(dirToTarget.x);
        float absy = Mathf.Abs(dirToTarget.y);
        float x = dirToTarget.x;
        float y = dirToTarget.y;

        if (absx > absy)
        {
            if (x > 0)
            {
                mySpriteRenderer.flipX = false;
                if (manager.currentMode == GoatDemonAttackManager.SpriteMode.charging)
                {
                    mySpriteRenderer.sprite = rightCharge;
                }
                else if (manager.currentMode == GoatDemonAttackManager.SpriteMode.fire) {
                    mySpriteRenderer.sprite = rightFire;
                }
                else
                {
                    mySpriteRenderer.sprite = rightIdle;
                }
                


                onCol.SetActive(false);
                onCol = updateCol.rtCol;
                onCol.SetActive(true);
            }
            else
            {
                mySpriteRenderer.flipX = true;
                if (manager.currentMode == GoatDemonAttackManager.SpriteMode.charging)
                {
                    mySpriteRenderer.sprite = rightCharge;
                }
                else if (manager.currentMode == GoatDemonAttackManager.SpriteMode.fire)
                {
                    mySpriteRenderer.sprite = rightFire;
                }
                else
                {
                    mySpriteRenderer.sprite = rightIdle;
                }

                onCol.SetActive(false);
                onCol = updateCol.ltCol;
                onCol.SetActive(true);
            }
        }
        else
        {
            if (y > 0)
            {
                if (manager.currentMode == GoatDemonAttackManager.SpriteMode.charging)
                {
                    mySpriteRenderer.sprite = upCharge;
                }
                else if (manager.currentMode == GoatDemonAttackManager.SpriteMode.fire)
                {
                    mySpriteRenderer.sprite = upFire;
                }
                else
                {
                    mySpriteRenderer.sprite = upIdle;
                }

                onCol.SetActive(false);
                onCol = updateCol.tpCol;
                onCol.SetActive(true);
            }
            else
            {
                if (manager.currentMode == GoatDemonAttackManager.SpriteMode.charging)
                {
                    mySpriteRenderer.sprite = downCharge;
                }
                else if (manager.currentMode == GoatDemonAttackManager.SpriteMode.fire)
                {
                    mySpriteRenderer.sprite = downFire;
                }
                else
                {
                    mySpriteRenderer.sprite = downIdle;
                }

                onCol.SetActive(false);
                onCol = updateCol.bmCol;
                onCol.SetActive(true);
            }
        }

    }
}
