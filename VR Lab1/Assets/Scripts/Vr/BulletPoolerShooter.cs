using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPoolerShooter : MonoBehaviour
{

    public static BulletPoolerShooter SharedInstance;
    private Animator _animator;
    private AudioSource _audioSource;
    private PlayerAim _playerAim;
    public int poolSize = 10;
    public int ProjectileCount { get; set; }
    private List<GameObject> _pooledBullets = new List<GameObject>();
    private List<GameObject> _pooledCaps = new List<GameObject>();

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

    [Tooltip("The shooting particle effect")]
    public ParticleSystem shootingParticle;

    void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _playerAim = GetComponentInChildren<PlayerAim>();
        ProjectileCount = poolSize; 
        RefreshAmmoText();
        for (int i = 0; i < poolSize; i++) 
        {
            GameObject obj = (GameObject)Instantiate(projectilePrefab);
            GameObject obj2 = (GameObject)Instantiate(projectileCapPrefab);
            obj.SetActive(false);
            obj2.SetActive(false);
            _pooledBullets.Add(obj);
            _pooledCaps.Add(obj2);
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

        _animator.Play("shoot");
        _audioSource.Play();

        TryToDestroyTarget();
        if(shootingParticle != null)
        {
            shootingParticle.Play();
        }
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
        for (int i = 0; i < _pooledBullets.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!_pooledBullets[i].activeInHierarchy)
            {
                return _pooledBullets[i];
            }
        }
        // otherwise, return null   
        return null;
    }

    public GameObject GetPooledCap()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < _pooledCaps.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!_pooledCaps[i].activeInHierarchy)
            {
                return _pooledCaps[i];
            }
        }
        // otherwise, return null   
        return null;
    }
    private void TryToDestroyTarget()
    {
        var hit = _playerAim.GetTarget();

        if(hit.collider == null)
        {
            return;
        }
        else
        {
            Debug.Log($"Colisiona con : {hit.collider.gameObject.name}");
            /*
             * en caso de haber puntuaciones aqui deberiamos solicitar la puntuacion correspondiente del objeto al que hayamos golpeado
             * hit.transform.GetComponent<>();
            */
            Destroy(hit.transform.gameObject);
        }
    }
}
