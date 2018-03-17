using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Projectile.ObjectPooling;
using Manager;


public class playerMovement: MonoBehaviour
{
    /// <summary> The GameObject holding the bullet spawn point. </summary>
    public Transform weaponRotation;
    public Util.SpriteFlasher spriteFlasher;
    /// <summary> The point to spawn the bullets at. </summary>
    public Transform bulletSpawn;
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
    public bool invincible;
    public bool turnOffY;
    private Renderer rend;
    private bool canFire;
    private bool changeMode;
  
    [SerializeField]
    public SoundPlayer sfx;

    [HideInInspector]
    public bool active;

    private bool allowDamage;
    [HideInInspector]
    public bool onlyX;



    // Use this for initialization
    void Awake()
    {
        player = gameObject;
        rtFace = true;
        horzFace = true;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        dir = "rt";
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        allowDamage = true;
        turnOffY = false;
        onlyX = false;
       
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteWidth = mySpriteRenderer.bounds.size.x;
        spriteHeight = mySpriteRenderer.bounds.size.y;
        this.boxcollider = this.GetComponent<BoxCollider2D>();
        active = true;
        canFire = true;
        changeMode = false;
    }
    void LateUpdate()
    {

        Flip();
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && canFire)
        {
            TestDirection();
            sfx.PlayShoot();
            Fire();
            canFire = false;
            Invoke("AllowFire", (float).2);
        } 
        CheckHealth();
      
    }

    void AllowFire()
    {
        canFire = true;
    }
    void CheckHealth()
    {
        if (GameObject.Find("HealthBar") != null)
        {
            GameObject healthBar = GameObject.Find("HealthBar");
            if (healthBar.transform.childCount == 0 && invincible != true)
            {
                sfx.PlayDie();
                gameObject.SetActive(false);
                rend.enabled = false;
            }
        }
       
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector3(moveHorizontal, moveVertical);
        if (onlyX)
        {
            movement = new Vector2(moveHorizontal, 0);
        } 
        else
        {
            movement = new Vector3(moveHorizontal, moveVertical);
        }
        

        if (active)
        {
            rb.velocity = movement * speed;
        }
        
    }

    void Fire()
    {
        float angle = 0;
        if (dir.Equals("lt"))
        {
            angle = Vector2.SignedAngle(Vector2.right, Vector2.left);
        }
        else if (dir.Equals("rt"))
        {
            angle = Vector2.SignedAngle(Vector2.right, Vector2.right);
        }
        else if (dir.Equals("tp"))
        {
            angle = Vector2.SignedAngle(Vector2.right, Vector2.up);
        }
        else if (dir.Equals("bm"))
        {
            angle = Vector2.SignedAngle(Vector2.right, Vector2.down);
        }

        this.weaponRotation.rotation = Quaternion.Euler(0, 0, angle);
        GameObject b = BulletPool.Instance.GetBullet(BulletPool.BulletTypes.Player);
        if (b != null)
        {
            b.transform.position = this.bulletSpawn.position;
            b.transform.rotation = this.bulletSpawn.rotation;
        }
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



    public float damageTimeout = 1f;
    private bool canTakeDamage = true;


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject healthBar = GameObject.Find("HealthBar");
        if (collision.gameObject.tag == "Enemy" && healthBar.transform.childCount != 0 && canTakeDamage)
        {
            healthBar.GetComponent<HealthBarUI>().RemoveLife();
            this.spriteFlasher.StartFlash();
            StartCoroutine(damageTimer());
            sfx.PlayPlayerHit();
        }
    }

    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageTimeout);
        canTakeDamage = true;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Elevator")
        {
            onlyX = true;
        }

        if (coll.gameObject.tag == "Heal")
        {
            sfx.PlayHeal();
        }
        
        if (coll.gameObject.tag == "Enemy")
        {
            GameObject healthBar = GameObject.Find("HealthBar");
            if (healthBar.transform.childCount != 0 && canTakeDamage)
            {
                healthBar.GetComponent<HealthBarUI>().RemoveLife();
                this.spriteFlasher.StartFlash();
                StartCoroutine(damageTimer());
                sfx.PlayPlayerHit();
            }
        }
    }

}

