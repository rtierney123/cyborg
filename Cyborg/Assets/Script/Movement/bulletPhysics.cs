using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPhysics : MonoBehaviour
{

    private Vector2 moveDirection;
    private Vector2 st;
    public float moveSpeed;
    private Rigidbody2D rb;
    private GameObject bullet;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Awake()
    {
        GameObject thePlayer = GameObject.Find("Player");
        playerMovement playerScript = thePlayer.GetComponent<playerMovement>();
        moveDirection = playerScript.direction;
        moveDirection.Normalize();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = (moveDirection * moveSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name != "Player") 
        {

            Destroy(this.gameObject);
        }
        
    }
}
