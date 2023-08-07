using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _range = 10f;
    [SerializeField] private GameObject _projectilePrefab;

    private Transform _target;
    private float _fireCountdown = 0f;

    void Update()
    {
        FindTarget();

        if (_target != null)
        {
            RotateHeadTowardsTarget();

            if (_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = 1f / _fireRate;
            }

            _fireCountdown -= Time.deltaTime;
        }
    }

    void FindTarget()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, _range);

        float shortestDistance = Mathf.Infinity;
        Transform nearestTarget = null;

        foreach (Collider target in targets)
        {
            if (target.CompareTag("Enemy"))
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
                if (distanceToTarget < shortestDistance)
                {
                    shortestDistance = distanceToTarget;
                    nearestTarget = target.transform;
                }
            }
        }

        _target = nearestTarget;
    }

    void RotateHeadTowardsTarget()
    {
        Vector3 direction = _target.position - _head.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(_head.rotation, lookRotation, Time.deltaTime * _rotationSpeed).eulerAngles;
        _head.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject projectileGO = Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
        Projectile projectile = projectileGO.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.SetTarget(_target);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
