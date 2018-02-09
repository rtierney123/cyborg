using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
    
{
    public GameObject healthDrop;


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            float randomNumber = Random.Range(0, 100);
            if (randomNumber < 20)
            {
                Instantiate(healthDrop, transform.position, Quaternion.identity);

            }

            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }
    }


}
