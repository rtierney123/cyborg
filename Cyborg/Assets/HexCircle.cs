using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexCircle : MonoBehaviour
{
    // Private References
    private List<CircleCollider2D> colliders = new List<CircleCollider2D>();
    private AudioSource whispers;
    private ParticleSystem particles;
    private SpriteRenderer hexCircleAura;
    private GameObject player;
    private Image darkness;

    // Runtime Variables
    private bool playerInsideCircle;

    // Constants
    private const float MAX_DARKNESS = 0.95f;
    private const float MIN_DARKNESS = 0.0f;
    private const float DARKNESS_RATE = 0.015f;

    private const float MAX_VOLUME = 0.3f;
    private const float MIN_VOLUME = 0.0f;
    private const float VOLUME_RATE = 0.005f;

    private const float MAX_AURA = 1.0f;
    private const float MIN_AURA = 0.0f;
    private const float AURA_RATE = 0.02f;

    public AudioSource background;

    // Use this for initialization
    void Start()
    {
        // Cache Private References
        whispers = this.gameObject.GetComponent<AudioSource>();
        particles = this.gameObject.GetComponent<ParticleSystem>();
        hexCircleAura = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        darkness = GameObject.FindGameObjectWithTag("Darkness").GetComponent<Image>();

        // Locate other Hex Circles
        HexCircle[] hexCircles = GameObject.FindObjectsOfType<HexCircle>();
        foreach (HexCircle h in hexCircles)
        {
            colliders.Add(h.GetComponent<CircleCollider2D>());
        }

        // Initialize Runtime Variables
        playerInsideCircle = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (CircleCollider2D c in colliders)
        {
            if (c.bounds.Contains(player.transform.position))
            {
                playerInsideCircle = true;
                background.volume = 0;
                return;
            }
        }
        playerInsideCircle = false;
        background.volume = (float).2;
    }

    // Update is called once per frame at a fixed rate
    void FixedUpdate()
    {
        AdjustDarkness();
        AdjustAudio();
        AdjustParticles();
        AdjustHexCircleAura();
    }

    // Change the darkness level based on if the player is inside the Hex Circle or not
    void AdjustDarkness()
    {
        if (playerInsideCircle)
        {
            if (darkness.color.a >= MAX_DARKNESS) { return; }
            darkness.color = new Color(0f, 0f, 0f, darkness.color.a + DARKNESS_RATE);
        }
        else
        {
            if (darkness.color.a <= MIN_DARKNESS) { return; }
            darkness.color = new Color(0f, 0f, 0f, darkness.color.a - DARKNESS_RATE);
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

    // Adjusts the "aura" around the Hex Circle based on if the player is inside the Hex Circle or not
    void AdjustHexCircleAura()
    {
        hexCircleAura.gameObject.transform.Rotate(Vector3.forward * -.9f);
        if (playerInsideCircle)
        {
            if (hexCircleAura.color.a >= MAX_AURA) { return; }
            hexCircleAura.color = new Color(1f, 1f, 1f, hexCircleAura.color.a + AURA_RATE);
        }
        else
        {
            if (hexCircleAura.color.a <= MIN_AURA) { return; }
            hexCircleAura.color = new Color(1f, 1f, 1f, hexCircleAura.color.a - (2 * AURA_RATE));
        }
    }
}
