using UnityEngine;

[System.Serializable]
public class EnemyHealth
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _enemyHealth = 100f;
    public CoinManager coinManager;

    private Enemy _enemy;
    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }
    public void ManualStart() 
    {
        _currentHealth = _enemyHealth;
    }
    public void UpdateHealth(float mod, Vector3 dir) {
        _currentHealth += mod;
        _enemy.EnemyVFX.Blood();
        if(_currentHealth <= 0)
        {
            Die(dir);
            _enemy.EnemyRig.ActiveRagdoll(dir);
        }

    }

    public void UpdateHealth(float mod)
    {
        _currentHealth += mod;
        _enemy.EnemyVFX.Blood();
        if (_currentHealth <= 0)
        {
            Die(Vector3.zero);
        }


    }
    private void Die(Vector3 dir)
    {
            if (_enemy.EnemyRig != null)
            {
                _enemy.EnemyRig.ActiveRagdoll(dir);
            }
            GameObject.Destroy(_enemy.gameObject, 5);
        coinManager.AddCoins(25);
    }

}