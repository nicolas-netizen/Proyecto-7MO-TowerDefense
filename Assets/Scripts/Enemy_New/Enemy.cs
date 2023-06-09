using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IWaveable
{

    [SerializeField] private EnemyChase _enemyChase;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private EnemyRig _enemyRig;
    [SerializeField] private EnemyVFX _enemyVFX;

    private Rigidbody rb;

    public EnemyChase EnemyChase { get => _enemyChase; set => _enemyChase = value; }
    public EnemyHealth EnemyHealth { get => _enemyHealth; set => _enemyHealth = value; }
    public EnemyRig EnemyRig { get => _enemyRig; set => _enemyRig = value; }
    public EnemyVFX EnemyVFX { get => _enemyVFX; set => _enemyVFX = value; }

    void Start()
    {
        _enemyChase.SetEnemy(this);
        _enemyHealth.SetEnemy(this);
        _enemyRig.SetEnemy(this);
        _enemyRig.ManualStart();
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

    public void TakeDamage(float mod, Vector3 dir)
    {
        _enemyHealth.UpdateHealth(-mod, dir);
    }

    public GameObject GetObject()
    {
        return gameObject;
    }

    public void NextNode(Node node)
    {
        _enemyChase.NextPoint = node;
    }
    public void ApplyKnockback(Vector3 direction, float force)
    {
        rb.AddForce(direction * force, ForceMode.Impulse);
    }
}

