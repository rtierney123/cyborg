using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
    
{
    public GameObject healthDrop;
    public int deathCount;
    private int hitCount;
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
          
            hitCount++;
            Destroy(coll.gameObject);
            if (deathCount == hitCount)
            {
                Destroy(this.gameObject);
                float randomNumber = Random.Range(0, 100);
                if (randomNumber < 20)
                {
                    Instantiate(healthDrop, transform.position, Quaternion.identity);

                }
            }
            
        }
    }


}
