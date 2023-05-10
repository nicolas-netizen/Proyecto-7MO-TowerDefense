using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    [SerializeField] private EnemyChase _enemyChase;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] public float explosionForce = 10f;
    [SerializeField] private Rigidbody rb;

    public EnemyChase EnemyChase { get => _enemyChase; set => _enemyChase = value; }
    public EnemyHealth EnemyHealth { get => _enemyHealth; set => _enemyHealth = value; }

    void Start()
    {
        _enemyChase.SetEnemy(this);
        _enemyHealth.SetEnemy(this);
        _enemyHealth.ManualStart();
    }

    // Update is called once per frame
    void Update()
    {
        _enemyChase.ManualUpdate();
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _enemyChase.RangeChase);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EndPoint")
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float mod)
    {
        _enemyHealth.UpdateHealth(-mod);
    }

    public GameObject GetObject()
    {
        return gameObject;
    }
    private void SetStart()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * explosionForce, ForceMode.Impulse);
    }
}

