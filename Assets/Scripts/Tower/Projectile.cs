using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float explosionRadius = 0f;

    private Transform target;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    private void Update()
    {
        if (target = null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - target.position;
        float distanceThisFrame = _speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage (Transform enemy)
    {
        Enemy e =  enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(_damage);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}