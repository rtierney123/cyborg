using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErraticAI : EnemyAI {
    public float chargeDelay;
    public float chargeDuration;
    private Rigidbody2D rb;
    private Vector2 dir;
    //used for erratic enemy, starting position for charge
    private Vector3 startPos;
    //end of charge time, duration of charge
    private float durationChargeTime;
    //boolean to tell whether to start charge
    private bool startCharge;
    //direction erratic enemy will charge
    private Vector2 erraticDir;
    //the time on the gameclock that the charge and start again
    private float pauseChargeTime;
    // whether to start a pause after a charge
    private bool pause;
    // position at end of charge
    private Vector3 finalposInOneDirection;

    //direction for sprite
    [HideInInspector]
    public string direction;
    public Sprite[] spriteArray;
    private SpriteRenderer mySpriteRenderer;
    private GameObject player;
    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }


    public override Vector2 move(Vector2 tan)
    {
        Vector3 targetPosition;
        if (player.active == false)
        {
            targetPosition = GameObject.Find("Player").transform.position;
        }   else
        {
            targetPosition = new Vector3(0, 0, 0);
        }
       
        Vector3 currentPosition = transform.position;
        Vector3 dirToPlayer = currentPosition - targetPosition;

        if (startCharge)
        {

            float absx = Mathf.Abs(dirToPlayer.x);
            float absy = Mathf.Abs(dirToPlayer.y);
            float x = dirToPlayer.x;
            float y = dirToPlayer.y;

            float distanceInOneDirection = 5;
            finalposInOneDirection = new Vector3();
            erraticDir = new Vector2();


            if (absx >= absy)
            {
                erraticDir = new Vector2(-dirToPlayer.x, 0);
                erraticDir = erraticDir.normalized;
                distanceInOneDirection = distanceInOneDirection * erraticDir.x;
                finalposInOneDirection = new Vector3(distanceInOneDirection + startPos.x, startPos.y, 0);
            }
            else
            {
                erraticDir = new Vector2(0, -dirToPlayer.y);
                erraticDir = erraticDir.normalized;
                distanceInOneDirection = distanceInOneDirection * erraticDir.y;
                finalposInOneDirection = new Vector3(distanceInOneDirection + tan.y, tan.y, 0);
            }
            erraticDir = ChooseDir(erraticDir);
            if (erraticDir.x == 1)
            {
                direction = "rt";
                mySpriteRenderer.flipX = true;
                mySpriteRenderer.flipY = false;
                mySpriteRenderer.sprite = spriteArray[0];

            }
            else if (erraticDir.x == -1)
            {
                direction = "lt";
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.flipY = false;
                mySpriteRenderer.sprite = spriteArray[0];

            }
            else if (erraticDir.y == 1)
            {
                direction = "tp";
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.flipY = true;
                mySpriteRenderer.sprite = spriteArray[1];

            }
            else if (erraticDir.y == -1)
            {
                direction = "bm";
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.flipY = false;
                mySpriteRenderer.sprite = spriteArray[1];

            }
        }
        startCharge = false;
        if (Time.time >= durationChargeTime)
        {
            pause = true;
            pauseChargeTime = durationChargeTime + chargeDelay;

            erraticDir = new Vector2(0, 0);
        }
        if (Time.time >= pauseChargeTime)
        {
            if (pause)
            {
                pause = false;
                startCharge = true;
                durationChargeTime = Time.time + chargeDuration;
            }
        }
        return getSpeed() * erraticDir;

    }
    public override void updateSprites()
    {

    }

    Vector2 ChooseDir(Vector2 erraticDir)
    {
        // make for possible vector directions for erratic to move
        Vector2 towardPlayer = erraticDir;
        Vector2 dir1 = -erraticDir;
        Vector2 dir2 = FlipCoords(erraticDir);
        Vector2 dir3 = FlipCoords(-erraticDir);

        float randomNumber = Random.Range(0, 100);
        Vector2 dir = new Vector2();
        if (randomNumber <= 50)
        {
            dir = erraticDir;
        }
        else if (randomNumber > 50 & randomNumber <= 60)
        {
            dir = dir1;
        }
        else if (randomNumber > 60 & randomNumber <= 80)
        {
            dir = dir2;
        }
        else
        {
            dir = dir3;
        }
        return dir;
    }

    Vector2 FlipCoords(Vector2 coord)
    {
        Vector2 newCoord = new Vector2();
        newCoord.x = coord.y;
        newCoord.y = coord.x;
        return newCoord;
    }


}
