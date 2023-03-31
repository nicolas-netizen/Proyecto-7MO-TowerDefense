using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
	[SerializeField] private int _maxLife = 100;
	[SerializeField] public int _currentHealth;
	private Player _player;

	public void ManualStart()
	{
		_currentHealth = _maxLife;
	}

	public void SetPlayer(Player player)
	{
		_player = player;
	}

	public void UpdateHealth(int mod)
	{
		_currentHealth += mod;
		if (_currentHealth <= 0)
			_player.gameObject.SetActive(false);
	}
}