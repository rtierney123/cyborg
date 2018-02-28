using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiply_enemy : MonoBehaviour {
    public GameObject healthDrop;
    public GameObject offspring;
    public int hitPoints;
    public int multiply_number;
    private int hitCount;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            hitCount++;
            Destroy(coll.gameObject);
            if (hitPoints == hitCount)
            {
                for (int i = 0; i < multiply_number; i++)
                {
                    Instantiate(offspring, transform.position, Quaternion.identity);
                }
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
