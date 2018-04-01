using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    private bool fire;

	// Use this for initialization
	void Start () {
        if (fire)
        {
            Invoke("DelayFire", 5);
            fire = false;
        }
        
	}

    private void DelayFire()
    {
        fire = true;
        Destroy(this);
    }

}
