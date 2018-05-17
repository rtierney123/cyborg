using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExplosion : MonoBehaviour {
    private AudioSource explosion;
	// Use this for initialization
	void Start () {
        explosion = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void OnEnable () {
        explosion.Play();
	}
}
