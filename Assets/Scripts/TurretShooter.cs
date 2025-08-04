using System;
using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    [SerializeField]
    private Transform _muzzleTransform;
    [SerializeField]
    private GameObject _projectile;
    [SerializeField]
    private float _shootForce = 1000;
    [SerializeField]
    private int _bulletsPerSecond = 10;
    [SerializeField]
    private float _projectileLifeTime = 10;


    private float _timeSinceLastShot = 0f;
    private bool _isShooting = false;

    public bool IsShooting 
    {
        get => _isShooting;

        set
        {
            _isShooting = value;
        }
    }

    private void ShootProjectile()
    {
        GameObject projectile = Instantiate(_projectile, _muzzleTransform.position, _muzzleTransform.rotation);

        Rigidbody body = projectile.GetComponent<Rigidbody>();
        if (body)
        {
            body.AddForce(_muzzleTransform.rotation * Vector3.forward * _shootForce, ForceMode.Impulse);
        }
        Destroy(projectile, _projectileLifeTime);
    }

    private void Update()
    {
        if (!_isShooting)
            return;

        float timeBetweenShots = 1f / _bulletsPerSecond;

        _timeSinceLastShot += Time.deltaTime;
        if(_timeSinceLastShot >= timeBetweenShots)
        {
            _timeSinceLastShot = 0;
            ShootProjectile();
        }

    }
}
