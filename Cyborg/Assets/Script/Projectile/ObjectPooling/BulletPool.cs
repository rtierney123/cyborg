namespace Projectile.ObjectPooling
{
    using UnityEngine;
    using Bullets;

    public class BulletPool : ObjectPool
    {
        [SerializeField]
        private Bullet[] bulletPools;
        [SerializeField]
        private int[] bulletPoolSizes;

        public enum BulletTypes { Player, Enemy, Puddle}

        /// <summary> Singleton instance for this object pool. </summary>
        public static BulletPool Instance { get; private set; }

        protected override void PreInit()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogError("Duplicate Bullet Pool detected: removing " + this.gameObject.name);
                Destroy(this.gameObject);
                return;
            }

            Instance = this;
        }

        protected override IPoolable[] GetTemplets()
        {
            return this.bulletPools;
        }

        protected override int[] GetPoolSizes()
        {
            return this.bulletPoolSizes;
        }

        public GameObject GetBullet(BulletTypes type)
        {
            IPoolable entity = AllocateEntity(bulletPools[(int)type]);
            if (entity == null)
                return null;

            return entity.GetGameObject();
        }

        public void ReturnBullet(BulletTypes type, GameObject bullet)
        {
            IPoolable entity = bullet.GetComponent<IPoolable>();
            DeallocateEntity(bulletPools[(int)type], entity);
        }
    }
}
