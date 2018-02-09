using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tech_basicEnemy_script : MonoBehaviour {


    public float moveSpeed;
    private Rigidbody2D rb;

    // Use this for initialization

    void OnTriggerEnter2D(Collider2D coll)
    {
      
        if (coll.gameObject.tag== "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
