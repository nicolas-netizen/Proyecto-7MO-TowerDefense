using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Enemy_Health 
{
	[SerializeField] private int _maxLife = 100;
	[SerializeField] public int _currentHealth;

	private Enemy _enemy;

	public void ManualStart()
	{
		_currentHealth = _maxLife;
	}

	public void SetEnemy(Enemy enemy)
	{
		_enemy = enemy;
	}

	public void UpdateHealth(int mod)
	{
		_currentHealth += mod;
		if (_currentHealth <= 0)
			_enemy.gameObject.SetActive(false);
	}
}
