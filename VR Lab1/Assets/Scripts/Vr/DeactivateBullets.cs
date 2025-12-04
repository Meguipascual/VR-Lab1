using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBullets : MonoBehaviour
{
    [Tooltip("Time before destroying in seconds")]
    public float lifeTime = 5.0f;

    public void DisableProjectile()
    {
        StartCoroutine("Disable");
    }

    public void DisableProjectileInmediately()
    {
        gameObject.SetActive(false);
        BulletPoolerShooter.SharedInstance.ProjectileCount++;
        BulletPoolerShooter.SharedInstance.RefreshAmmoText();
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
        BulletPoolerShooter.SharedInstance.ProjectileCount++;
        BulletPoolerShooter.SharedInstance.RefreshAmmoText();
    }
}
