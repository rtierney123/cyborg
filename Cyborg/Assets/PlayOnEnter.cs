using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnEnter : MonoBehaviour {
    private AudioSource source;
    private bool allowPlay;
    public AudioSource backgroundMusic;
    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        allowPlay = false;
    } 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!allowPlay)
            {
                source.enabled = true;
                allowPlay = true;
                backgroundMusic.enabled = false;
            }

        }
    }
}
