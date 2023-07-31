using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerHealth
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private Animator _animator;

    public EnemySpawner enemySpawner;

    public void Start()
    {
        currentHealth = maxHealth;
    }
    private Player _player;
    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Player died.");
        if (_animator != null)
        {
            _animator.SetTrigger("Death"); 
        }
    }
}

