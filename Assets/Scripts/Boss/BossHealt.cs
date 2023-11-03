using UnityEngine;

[System.Serializable]
public class BossHealth
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _enemyHealth = 100f;

    private Boss _enemy;

    public float CurrentHealth { get => _currentHealth; }

    public void SetEnemy(Boss enemy)
    {
        _enemy = enemy;
    }
    public void ManualStart()
    {
        _currentHealth = _enemyHealth;
    }

    public void UpdateHealth(float mod, Vector3 dir)
    {
        _currentHealth -= mod;
        _enemy.EnemyVFX.Blood();
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die(dir);
        }
    }

    public void UpdateHealth(float mod)
    {
        _currentHealth -= mod;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die(Vector3.zero);
        }
        else
            _enemy.EnemyVFX.Blood();

    }

    private void Die(Vector3 dir)
    {
        if (_enemy.EnemyRig != null)
        {
            _enemy.EnemyRig.ActiveRagdoll(dir);
        }
        _enemy.gameObject.layer = LayerMask.NameToLayer("Ignore");
        GameObject.Destroy(_enemy.gameObject, 5);
    }
}