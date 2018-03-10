using UnityEngine;

public class multiply_enemy : MonoBehaviour
{
    public Util.SpriteFlasher spriteFlasher;
    public GameObject healthDrop;
    public GameObject offspring;
    public int hitPoints;
    public int multiply_number;
    private int hitCount;
    private Transform enemyParent;
    private void Start()
    {
        enemyParent = gameObject.transform.parent;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            if (!this.spriteFlasher.IsInvicible())
            {
                hitCount++;
                if (hitPoints == hitCount)
                {
                    for (int i = 0; i < multiply_number; i++)
                    {
                        Instantiate(offspring, transform.position, Quaternion.identity, enemyParent);
                    }
                    Destroy(this.gameObject);
                    float randomNumber = Random.Range(0, 100);
                    if (randomNumber < 20)
                    {
                        Instantiate(healthDrop, transform.position, Quaternion.identity);
                    }
                }
                else
                    this.spriteFlasher.StartFlash();
            }
        }
      
    }
}
