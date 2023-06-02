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
        if(_currentHealth <= 0)
        {
            Die();
            _enemy.EnemyRig.ActiveRagdoll(dir);
        }

    }
    void Die() {
        GameObject.Destroy(_enemy.gameObject,5);
    }
}
