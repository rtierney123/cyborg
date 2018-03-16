using UnityEngine;
using Manager;

public class enemy : MonoBehaviour
{
    public Util.SpriteFlasher spriteFlasher;
    public GameObject healthDrop;
    public int deathCount;

    private int hitCount;

    [SerializeField]
    public SoundPlayer sfx;

    private void Start()
    {
        sfx = GameObject.Find("SoundManager").GetComponent<SoundPlayer>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            if (!this.spriteFlasher.IsInvicible())
            {
                this.hitCount++;
                sfx.PlayEnemyHit();
                if (this.deathCount == this.hitCount)
                {
                    Destroy(this.gameObject);
                    float randomNumber = Random.Range(0, 100);
                    if (randomNumber < 20)
                    {
                        Instantiate(this.healthDrop, this.transform.position, Quaternion.identity);
                    }
                }
                else
                    this.spriteFlasher.StartFlash();
            }
        }
    }
}
