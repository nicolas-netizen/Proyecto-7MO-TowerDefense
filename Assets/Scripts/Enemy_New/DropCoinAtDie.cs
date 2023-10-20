using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCoinAtDie : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private AudioSource CoinAudio;
    private bool _flagOnce;
    public void Update()
    {
        if (_enemy.EnemyHealth.CurrentHealth <= 0 && !_flagOnce)
        {
            CoinAudio.Play();
            CoinManager.Instance.AddCoins(25);
            _flagOnce = true;
            _enemy.EnemyVFX.MoneyDie();
        }
    }
}
