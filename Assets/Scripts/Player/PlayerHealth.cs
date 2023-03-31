using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerHealth
{
	[SerializeField] private int _maxLife = 100;
	[SerializeField] public int _currentHealth;
	[SerializeField] private Slider _lifeBar;
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
		_lifeBar.value = _currentHealth;
		if (_currentHealth <= 0)
			_player.gameObject.SetActive(false);
    }
}
