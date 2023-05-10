using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerHealth
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

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
        Debug.Log("Player took " + damageAmount + " damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died.");
       
    }
}

