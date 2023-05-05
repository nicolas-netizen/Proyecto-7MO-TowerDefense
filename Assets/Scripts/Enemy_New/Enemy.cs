using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private EnemyChase _enemyChase;

    public EnemyChase EnemyChase { get => _enemyChase; set => _enemyChase = value; }

    void Start()
    {
        _enemyChase.SetEnemy(this);
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
}
