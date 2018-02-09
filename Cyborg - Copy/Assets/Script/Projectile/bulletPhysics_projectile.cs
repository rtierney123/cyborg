using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPhysics_projectile : MonoBehaviour {

    private Vector2 moveDirection;
    private Vector2 st;
    public float moveSpeed;
    private Rigidbody2D rb;
    private GameObject enemy;
 
    private bool firstRun;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        firstRun = true;
    }

    void FindDirection()
    {
        enemy = transform.parent.gameObject;
        moveDirection = enemy.GetComponent<projectileScriptforEnemy>().moveDirection;
        moveDirection.Normalize();
    
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = (moveDirection * moveSpeed);
    }
    void LateUpdate()
    {
        if (firstRun)
        {
            FindDirection();
            firstRun = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }

    }
}
