using UnityEngine;

[System.Serializable]
public class EnemyMhealth
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _enemyHealth = 100f;

    private EnemyM _enemy;

    public void SetEnemy(EnemyM enemy)
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