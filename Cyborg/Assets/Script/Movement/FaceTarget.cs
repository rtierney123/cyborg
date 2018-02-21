using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget : MonoBehaviour {
    public GameObject target;
    public Sprite down;
    public Sprite up;
    public Sprite right;

    private SpriteRenderer mySpriteRenderer;
    private Vector2 currentPos;
    private Vector2 targetPos;
    private Vector2 dirToTarget;
	// Use this for initialization
	void Start () {
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
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
                mySpriteRenderer.sprite = right;
            }
            else
            {
                mySpriteRenderer.flipX = true;
                mySpriteRenderer.sprite = right;
            }
        } else
        {
            if (y > 0)
            {
                mySpriteRenderer.sprite = up;
            } else
            {
                mySpriteRenderer.sprite = down;
            }
        }

    }
}
