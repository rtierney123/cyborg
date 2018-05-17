using UnityEngine;
using Manager;

public class FinalBossEnemy : MonoBehaviour
{
    public Util.SpriteFlasher spriteFlasher;
    public GameObject healthDrop;
    public int deathCount;
    public GameObject explosion;
    private int hitCount;
    private AudioSource hitSound;

    public Dialog dialogue;

    [SerializeField]
    //public SoundPlayer sfx;

    private void Start()
    {
        hitSound = GameObject.Find("EnemyHit").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            if (!this.spriteFlasher.IsInvicible())
            {
                this.hitCount++;
                hitSound.Play();
                if (this.deathCount == this.hitCount)
                {
                    TriggerDialogue();

                    Invoke("Explode", (float).2);

                }
                else
                    this.spriteFlasher.StartFlash();
            }
        }
    }
    void Explode()
    {
        Vector2 explosionpos = this.transform.position;
        this.gameObject.SetActive(false);
        explosion.SetActive(true);
        explosion.transform.position = explosionpos;
        Invoke("ExplosionDisappear", 2);
    }
    void ExplosionDisappear()
    {
        explosion.SetActive(false);
        Destroy(this.gameObject);
    }
   
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }
}
