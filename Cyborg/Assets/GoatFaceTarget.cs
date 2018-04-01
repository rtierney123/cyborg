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

    public Transform ltColCharge;
    public Transform ltColFire;
    public Transform rtColCharge;
    public Transform rtColFire;
    public Transform tpColCharge;
    public Transform tpColFire;
    public Transform bmColCharge;
    public Transform bmColFire;

    public GameObject rtCone;
    public GameObject ltCone;
    public GameObject tpCone;
    public GameObject bmCone;
    private GameObject currentCone;

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
        onCol = ltColCharge.gameObject;
        manager = this.GetComponent<GoatDemonAttackManager>();
        currentCone = rtCone;
        currentCone.SetActive(false);
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

        currentCone.SetActive(false);

        if (absx > absy)
        {
            if (x > 0)
            {
                mySpriteRenderer.flipX = false;
                onCol.SetActive(false);
                if (manager.currentMode == GoatDemonAttackManager.SpriteMode.charging)
                {
                    mySpriteRenderer.sprite = rightCharge;
                    onCol = rtColCharge.gameObject;
                }
                else if (manager.currentMode == GoatDemonAttackManager.SpriteMode.fire) {
                    mySpriteRenderer.sprite = rightFire;
                    onCol = rtColFire.gameObject;
                    currentCone = rtCone;
                    currentCone.SetActive(true);
                }
                else
                {
                    mySpriteRenderer.sprite = rightIdle;
                    onCol = rtColFire.gameObject;
                }
                onCol.SetActive(true);


                
            }
            else
            {
                mySpriteRenderer.flipX = true;
                onCol.SetActive(false);

                if (manager.currentMode == GoatDemonAttackManager.SpriteMode.charging)
                {
                    mySpriteRenderer.sprite = rightCharge;
                    onCol = ltColCharge.gameObject;
                }
                else if (manager.currentMode == GoatDemonAttackManager.SpriteMode.fire)
                {
                    mySpriteRenderer.sprite = rightFire;
                    onCol = ltColFire.gameObject;
                    currentCone = ltCone;
                    currentCone.SetActive(true);
                }
                else
                {
                    mySpriteRenderer.sprite = rightIdle;
                    onCol = ltColFire.gameObject;
                }
                onCol.SetActive(true);
            }
        }
        else
        {
            if (y > 0)
            {
                onCol.SetActive(false);
                if (manager.currentMode == GoatDemonAttackManager.SpriteMode.charging)
                {
                    mySpriteRenderer.sprite = upCharge;
                    onCol = tpColCharge.gameObject;
                }
                else if (manager.currentMode == GoatDemonAttackManager.SpriteMode.fire)
                {
                    mySpriteRenderer.sprite = upFire;
                    onCol = tpColFire.gameObject;
                    currentCone = tpCone;
                    currentCone.SetActive(true);
                }
                else
                {
                    mySpriteRenderer.sprite = upIdle;
                    onCol = tpColFire.gameObject;
                }
                onCol.SetActive(true);
            }
            else
            {
                onCol.SetActive(false);
                if (manager.currentMode == GoatDemonAttackManager.SpriteMode.charging)
                {
                    mySpriteRenderer.sprite = downCharge;
                    onCol = bmColCharge.gameObject;
                }
                else if (manager.currentMode == GoatDemonAttackManager.SpriteMode.fire)
                {
                    mySpriteRenderer.sprite = downFire;
                    onCol = bmColFire.gameObject;
                    currentCone = bmCone;
                    currentCone.SetActive(true);
                }
                else
                {
                    mySpriteRenderer.sprite = downIdle;
                    onCol = bmColFire.gameObject;
                }
                onCol.SetActive(true);
            }
        }
    

    }

    private void TurnOffCone()
    {
        currentCone.SetActive(false);
    }
}
