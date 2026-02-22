using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBullets : MonoBehaviour
{
    [Tooltip("Time before destroying in seconds")]
    public float lifeTime = 5.0f;

    public BulletPoolerShooter BulletPooler {  get; set; }

    public void DisableProjectile()
    {
        StartCoroutine("Disable");
    }

    public void DisableProjectileInmediately()
    {
        gameObject.SetActive(false);
        BulletPooler.ProjectileCount++;
        BulletPooler.RefreshAmmoText();
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
        BulletPooler.ProjectileCount++;
        BulletPooler.RefreshAmmoText();
    }
}
