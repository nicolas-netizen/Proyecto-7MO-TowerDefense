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
    public void UpdateHealth(float mod, Vector3 dir) {
        _currentHealth += mod;
        _enemy.EnemyVFX.Blood();
        if(_currentHealth <= 0)
        {
            Die();
            _enemy.EnemyRig.ActiveRagdoll(dir);
        }

    }

    public void UpdateHealth(float mod)
    {
        _currentHealth += mod;
        _enemy.EnemyVFX.Blood();
        if (_currentHealth <= 0)
        {
            Die();
        }

    }

    void Die() {
        _enemy.gameObject.layer = LayerMask.NameToLayer("Ignore");
        GameObject.Destroy(_enemy.gameObject,5);
    }
}
