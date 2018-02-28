namespace Util
{
    using UnityEngine;

    public class SpriteFlasher : MonoBehaviour
    {
        /// <summary> The amount of time this character is invulnerable. </summary>
        [SerializeField]
        [Tooltip("The amount of time this character is invulnerable.")]
        private float invulnerabilityTime = .5f;

        /// <summary> How long to wait between flashes. </summary>
        [SerializeField]
        [Tooltip("How long to wait between flashes.")]
        private float flashInterval = .09f;

        /// <summary> The sprite to turn on and off. </summary>
        [SerializeField]
        [Tooltip("The sprite to turn on and off.")]
        public SpriteRenderer sprite;
        
        /// <summary> Tracks if this entity is currently invulnerable. </summary>
        private bool isInvulnerable = false;
        /// <summary> Tracks if the renderer is currently on. </summary>
        private bool isVisible = true;
        /// <summary> The timer to keep track of how long to flash. </summary>
        private float invunTimer = 0;
        /// <summary> The timer to keep track of when to flip the renderer on or off. </summary>
        private float flashTimer = 0;

        private void Update()
        {
            if (this.invunTimer > 0f)
            {
                if (this.flashTimer > this.flashInterval)
                {
                    this.isVisible = !isVisible;
                    this.flashTimer = 0f;
                    this.sprite.enabled = isVisible;
                }

                this.flashTimer += Time.deltaTime;
                this.invunTimer -= Time.deltaTime;
            }
            else if (!isVisible || isInvulnerable)
            {
                this.isVisible = true;
                this.sprite.enabled = true;
                this.isInvulnerable = false;
            }
        }

        /// <summary> Returns if the entity is invincible. </summary>
        /// <returns> True if the entity is invincible. </returns>
        public bool IsInvicible()
        {
            return this.isInvulnerable;
        }

        /// <summary> Start the sprite flashing. </summary>
        public void StartFlash()
        {
            this.isInvulnerable = true;
            this.invunTimer = this.invulnerabilityTime;
        }
    }
}
