using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScriptforEnemy : MonoBehaviour {
    public GameObject projectile;
    public int fireRate;

    private SpriteRenderer mySpriteRenderer;
    private float pauseProjectile;
    private string facingDirection;
    private Vector3 bulletplace;
    private float spriteWidth;
    private float spriteHeight;
    [HideInInspector]
    public Vector2 moveDirection;
  
    // Use this for initialization
    void Start () {
        pauseProjectile = Time.time + 1;
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteWidth = mySpriteRenderer.bounds.size.x;
        spriteHeight = mySpriteRenderer.bounds.size.y;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= pauseProjectile)
        {
            pauseProjectile = Time.time + 5;
            Fire();

        }


    }
    void Fire()
    {
        facingDirection = gameObject.GetComponent<ProjectileAI>().direction;
        if (facingDirection == "lt")
        {
            bulletplace = new Vector3(transform.position.x - spriteWidth / 2-1, transform.position.y, 0);
        }
        else if (facingDirection == "rt")
        {
            bulletplace = new Vector3(transform.position.x + spriteWidth / 2+1, transform.position.y, 0);
        }
        else if (facingDirection == "bm")
        {
            bulletplace = new Vector3(transform.position.x, transform.position.y - spriteHeight / 2-1, 1);
        }
        else if (facingDirection == "tp")
        {
            bulletplace = new Vector3(transform.position.x, transform.position.y + spriteHeight / 2+1, 0);
        }
        moveDirection = gameObject.GetComponent<ProjectileAI>().projectileDir;
        var bullet = Instantiate(projectile, bulletplace, Quaternion.identity);
        bullet.transform.parent = this.gameObject.transform;
    }
 
}
