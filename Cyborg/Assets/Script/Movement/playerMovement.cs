using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerMovement: MonoBehaviour
{

    public float speed;
    public GameObject projectile;
    public Vector3 direction;
    public Vector2 playerPos;
    public Sprite[] spritArray;
    public int change;

    [HideInInspector]
    public BoxCollider2D boxcollider;
    private GameObject player;
    private bool rtFace;
    private bool horzFace;
    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D rb;
    private string dir;
    private Vector3 bulletplace;
    private float spriteWidth;
    private float spriteHeight;
    public int count;
    public bool triggered;
    public AudioSource projectileSound;
    public bool invincible;
    private Renderer rend;

    [HideInInspector]
    public bool active;

    private bool allowDamage;




    // Use this for initialization
    void Awake()
    {
        player = GameObject.Find("Player");
        rtFace = true;
        horzFace = true;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        dir = "rt";
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        allowDamage = true;


    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteWidth = mySpriteRenderer.bounds.size.x;
        spriteHeight = mySpriteRenderer.bounds.size.y;
        this.boxcollider = this.GetComponent<BoxCollider2D>();
        active = true;
    }
    void LateUpdate()
    {
        Flip();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TestDirection();
     
            Fire();
            
        }
        CheckHealth();
      
    }
    void CheckHealth()
    {
        if (GameObject.Find("HealthBar") != null)
        {
            GameObject healthBar = GameObject.Find("HealthBar");
            if (healthBar.transform.childCount == 0 && invincible != true)
            {
                gameObject.active = false;
                rend.enabled = false;
            }
        }
       
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector3(moveHorizontal, moveVertical);

        if (active)
        {
            rb.velocity = movement * speed;
        }
        
    }








    void Fire()
    {

         
            count++;
            if (dir.Equals("lt"))
            {
                bulletplace = new Vector3(transform.position.x-spriteWidth/2, transform.position.y, 0);
            }
            else if (dir.Equals("rt"))
            {
                bulletplace = new Vector3(transform.position.x + spriteWidth / 2, transform.position.y,0);
            }
            else if (dir.Equals("tp"))
            {
                bulletplace = new Vector3(transform.position.x, transform.position.y+spriteHeight/2, 0);
            }
            else if (dir.Equals("bm"))
            {
                bulletplace = new Vector3(transform.position.x, transform.position.y-spriteHeight /2,1);
            }
        

            Instantiate(projectile, bulletplace, Quaternion.identity);
        
    }
    void Flip()
    {
        if (mySpriteRenderer != null)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (rtFace)
                {
                    mySpriteRenderer.flipX = true;
                    rtFace = false;
                }
                else if (!horzFace)
                {
                    mySpriteRenderer.sprite = spritArray[0];
                    mySpriteRenderer.flipX = true;
                    rtFace = false;
                }
                horzFace = true;
                dir = "lt";

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (!rtFace && horzFace)
                {
                    mySpriteRenderer.flipX = false;
                    rtFace = true;
                }
                else if (!horzFace)
                {
                    mySpriteRenderer.sprite = spritArray[0];
                }
                horzFace = true;
                dir = "rt";

            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = spritArray[1];
                horzFace = false;
                rtFace = false;
                dir = "tp";
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                mySpriteRenderer.flipX = false;
                mySpriteRenderer.sprite = spritArray[2];
                horzFace = false;
                rtFace = false;
                dir = "bm";
            }

        }
    }
    void TestDirection()
    {
        if (dir.Equals("lt"))
        {
            direction.x = -change;
            direction.y = 0;
        }
        else if (dir.Equals("rt"))
        {
            direction.x = change;
            direction.y = 0;
        }
        else if (dir.Equals("tp"))
        {
            direction.x = 0;
            direction.y = change;
        }
        else if (dir.Equals("bm")){
            direction.x = 0;
            direction.y = -change;
        }
    }


    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject healthBar = GameObject.Find("HealthBar");

        if (collision.gameObject.tag == "Enemy" && healthBar.transform.childCount != 0)
        {
            Debug.Log("hit" + countHits);
            Debug.Log(allowDamage);
            countHits++;
            if (allowDamage)
            {
                healthBar.GetComponent<HealthBarUI>().RemoveLife();
                allowDamage = false;
                StartCoroutine(DelayHits());
            }
            
        }

    }
    */

    public float damageTimeout = 1f;
    private bool canTakeDamage = true;


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject healthBar = GameObject.Find("HealthBar");
        if (collision.gameObject.tag == "Enemy" && healthBar.transform.childCount != 0 && canTakeDamage)
        {
            healthBar.GetComponent<HealthBarUI>().RemoveLife();
            StartCoroutine(damageTimer());
        }

    }

    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageTimeout);
        canTakeDamage = true;
    }


}

