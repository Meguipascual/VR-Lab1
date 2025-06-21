using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletPoolerShooter : MonoBehaviour
{

    public static BulletPoolerShooter SharedInstance;
    private Animator animator;
    private AudioSource audioSource;
    public int poolSize = 10;
    public int ProjectileCount { get; set; }
    private List<GameObject> pooledBullets = new List<GameObject>();
    private List<GameObject> pooledCaps = new List<GameObject>();

    [Tooltip("The Bullet that's created")]
    public GameObject projectilePrefab = null;

    [Tooltip("The Cap that's created")]
    public GameObject projectileCapPrefab = null;

    [Tooltip("The point that the Bullet is created")]
    public Transform bulletStartPoint = null;

    [Tooltip("The point that the Cap is created")]
    public Transform capStartPoint = null;

    [Tooltip("The speed at which the Bullet is launched")]
    public float bulletLaunchSpeed = 1.0f;

    [Tooltip("The speed at which the Cap is launched")]
    public float capLaunchSpeed = 1.0f;

    [Tooltip("The projectile that's created")]
    public TextMeshProUGUI ammoText;

    void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        ProjectileCount = poolSize; 
        RefreshAmmoText();
        for (int i = 0; i < poolSize; i++) 
        {
            GameObject obj = (GameObject)Instantiate(projectilePrefab);
            GameObject obj2 = (GameObject)Instantiate(projectileCapPrefab);
            obj.SetActive(false);
            obj2.SetActive(false);
            pooledBullets.Add(obj);
            pooledCaps.Add(obj2);
        }
    }

    public void Fire()
    {
        if (ProjectileCount <= 0)
        {
            return;
        }

        var bullet = GetPooledbullet();
        var cap = GetPooledCap();

        ActivateBullet(bullet);
        AcctivateCap(cap);

        ApplyForceBullet(bullet);
        ApplyForceCap(cap);

        animator.Play("shoot");
        audioSource.Play();

        ProjectileCount--;
        RefreshAmmoText();
    }

    private void ApplyForceCap(GameObject cap)
    {
        if (cap.TryGetComponent(out Rigidbody rigidBody))
        {
            ApplyForce(rigidBody, capStartPoint);
        }
    }

    private void ApplyForceBullet(GameObject bullet)
    {
        if (bullet.TryGetComponent(out Rigidbody rigidBody))
        {
            ApplyForce(rigidBody, bulletStartPoint);
        }
    }

    private void AcctivateCap(GameObject cap)
    {
        cap.transform.position = capStartPoint.position;
        cap.transform.rotation = capStartPoint.rotation;
        cap.SetActive(true);
        cap.GetComponent<DeactivateInSeconds>().DisableProjectile();
    }

    private void ActivateBullet(GameObject bullet)
    {
        bullet.transform.position = bulletStartPoint.position;
        bullet.transform.rotation = bulletStartPoint.rotation;
        bullet.SetActive(true);
        bullet.GetComponent<DeactivateBullets>().DisableProjectile();
    }

    private void ApplyForce(Rigidbody rigidBody, Transform startPoint)
    {
        Vector3 force = startPoint.forward * bulletLaunchSpeed;
        rigidBody.AddForce(force);
    }
    public void RefreshAmmoText()
    {
        ammoText.text = $"Bullets: {ProjectileCount}";
    }
    public GameObject GetPooledbullet()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }
        // otherwise, return null   
        return null;
    }

    public GameObject GetPooledCap()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledCaps.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledCaps[i].activeInHierarchy)
            {
                return pooledCaps[i];
            }
        }
        // otherwise, return null   
        return null;
    }
}
