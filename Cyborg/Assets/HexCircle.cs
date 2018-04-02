using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexCircle : MonoBehaviour
{
    // Private References
    private CircleCollider2D collider;
    private AudioSource whispers;
    private ParticleSystem particles;
    private GameObject player;
    private Image Darkness;

    // Runtime Variables
    private bool playerInsideCircle;

    // Constants
    private const float MAX_DARKNESS = 1.0f;
    private const float MIN_DARKNESS = 0.0f;
    private const float DARKNESS_RATE = 0.02f;
    private const float MAX_VOLUME = 0.3f;
    private const float MIN_VOLUME = 0.0f;
    private const float VOLUME_RATE = 0.005f;
	// Use this for initialization
	void Start ()
    {
        // Cache Private References
        collider = this.gameObject.GetComponent<CircleCollider2D>();
        whispers = this.gameObject.GetComponent<AudioSource>();
        particles = this.gameObject.GetComponent<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("Player");
        Darkness = GameObject.FindGameObjectWithTag("Darkness").GetComponent<Image>();

        // Initialize Runtime Variables
        playerInsideCircle = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(collider.bounds.Contains(player.transform.position))
        {
            playerInsideCircle = true;
        }
        else
        {
            playerInsideCircle = false;
        }
    }

    // Update is called once per frame at a fixed rate
    void FixedUpdate()
    {
        AdjustDarkness();
        AdjustAudio();
        AdjustParticles();
    }

    // Change the darkness level based on if the player is inside the Hex Circle or not
    void AdjustDarkness()
    {
        if(playerInsideCircle)
        {
            if(Darkness.color.a >= MAX_DARKNESS){return;}
            Darkness.color = new Color(0f, 0f, 0f, Darkness.color.a + DARKNESS_RATE);
        }
        else
        {
            if (Darkness.color.a <= MIN_DARKNESS) { return; }
            Darkness.color = new Color(0f, 0f, 0f, Darkness.color.a - DARKNESS_RATE);
        }
    }

    // Adjusts the audio based on if the player is inside the Hex Circle or not
    void AdjustAudio()
    {
        if (playerInsideCircle)
        {
            if (whispers.volume >= MAX_VOLUME) { return; }
            whispers.volume += VOLUME_RATE;
        }
        else
        {
            if (whispers.volume <= MIN_VOLUME) { return; }
            whispers.volume -= VOLUME_RATE;
        }
    }

    // Adjusts the emitting particles based on if the player is inside the Hex Circle or not
    void AdjustParticles()
    {
        if (playerInsideCircle)
        {
            particles.enableEmission = true;
        }
        else
        {
            particles.enableEmission = false;
        }
    }
}
