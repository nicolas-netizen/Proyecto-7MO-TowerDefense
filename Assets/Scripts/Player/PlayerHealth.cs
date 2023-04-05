using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerHealth
{
	[SerializeField] private int _maxLife = 100;
	[SerializeField] public float _currentHealth;
	[SerializeField] private Image _lifeBar;
	[SerializeField] public Text _Textlife;
	private Player _player;


	public void ManualStart()
	{
		_currentHealth = _maxLife;
	}

	public void ManualUpdate()
	{
		_lifeBar.fillAmount = _currentHealth / 100;
		_Textlife.text = "salud: " + _currentHealth.ToString("f0");
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
	public void RecibirDaño(float daño)
	{
		_currentHealth -= daño;
	}
}
