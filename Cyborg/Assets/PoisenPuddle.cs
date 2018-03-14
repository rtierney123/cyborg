using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Projectile.ObjectPooling;

public class PoisenPuddle : Attack {
    private bool canMakePuddle = true;
    public Transform puddleLocation;
    public override Vector2 move(Vector2 tan)
    {
        return getSpeed() * tan;

    }
    public override void updateSprites()
    {

    }

    public override void attack()
    {
        if (canMakePuddle)
        {
            StartCoroutine(DelayCreatePuddle());
        }  
    }

    IEnumerator DelayCreatePuddle()
    {
        stopPuddle();

        yield return 100000;

        makePuddle();
    }

    private void stopPuddle()
    {
        canMakePuddle = false;
    }

    private void makePuddle()
    {
        canMakePuddle = true;
        GameObject b = BulletPool.Instance.GetBullet(BulletPool.BulletTypes.Puddle);

        if (b != null)
        {
            b.transform.position = puddleLocation.position;
            Debug.Log(puddleLocation.position.x);
            b.transform.rotation = puddleLocation.rotation;
        }
    }

    private void LateUpdate()
    {
        attack();
    }
}
