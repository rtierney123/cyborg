using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFlash : MonoBehaviour {
    public Util.SpriteFlasher spriteFlasher;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            this.spriteFlasher.StartFlash();
        }
    }

}
