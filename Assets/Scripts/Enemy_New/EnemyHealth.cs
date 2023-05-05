using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyHealth
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _enemyHealth = 100f;

    private Enemy _enemy;
    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }
    public void ManualStart() 
    {
        _currentHealth = _enemyHealth;
    }
    public void TakeDamage(float damage) {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            Die();
        }
    }
    void Die() {


    }

    
}
