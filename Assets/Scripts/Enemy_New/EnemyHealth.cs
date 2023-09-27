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
            coinManager.AddCoins(25);
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
        if (_enemy != null)
        {
            if (_enemy.EnemyRig != null)
            {
                _enemy.EnemyRig.ActiveRagdoll(dir);
            }
            _enemy.gameObject.layer = LayerMask.NameToLayer("Ignore");
            GameObject.Destroy(_enemy.gameObject, 5);

        }
    }


}