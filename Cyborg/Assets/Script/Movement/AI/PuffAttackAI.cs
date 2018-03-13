using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffAttackAI : Attack {

    private GameObject target;
    private bool attacking;
    private bool expanding;
    private bool shrinking;

    public float puffDuration;
    public float puffAmount;
    public float attackPower;

    void Start()
    {
        target = GameObject.Find("Player");
        attacking = false;
    }

    public override Vector2 move(Vector2 tan)
    {
        if (!attacking)
        {
            return getSpeed() * tan;
        } else
        {
            return new Vector3(0, 0, 0);
        }
        
    }

    public override void updateSprites()
    {
        
    }

    public override void attack()
    {
        attacking = true;

        Expand();
        Invoke("Shrink", puffDuration / 2);
        Invoke("EndPuff", puffDuration);
    }

    void Expand()
    {
        expanding = true;
        shrinking = false;
    }

    void Shrink()
    {
        expanding = false;
        shrinking = true;
    }

    void EndPuff()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        expanding = false;
        shrinking = false;
        attacking = false;
    }

    void FixedUpdate()
    {
        if (expanding)
        {
            transform.localScale += new Vector3(puffAmount * transform.localScale.x, puffAmount * transform.localScale.y, 0) * Time.deltaTime;
            Color c = GetComponent<SpriteRenderer>().color;
            c.g -= Time.deltaTime * 3;
            if (c.g < 0)
            {
                c.g = 0;
            }
            GetComponent<SpriteRenderer>().color = new Color(c.r, c.b, c.g);
        } else if (shrinking)
        {
            transform.localScale -= new Vector3(puffAmount * transform.localScale.x, puffAmount * transform.localScale.y, 0) * Time.deltaTime;
            Color c = GetComponent<SpriteRenderer>().color;
            c.g += Time.deltaTime * 3;
            if (c.g > 255)
            {
                c.g = 255;
            }
            GetComponent<SpriteRenderer>().color = new Color(c.r, c.b, c.g);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!attacking && collision.gameObject == target)
        {
            
            Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
            target.GetComponent<playerMovement>().active = false;
            Invoke("EnablePlayer", attackPower + puffDuration);
            rb.AddForce((target.transform.position - transform.position).normalized * attackPower * 100);
            attack();
        }
    }

    void EnablePlayer()
    {
        target.GetComponent<playerMovement>().active = true;
    }
}
