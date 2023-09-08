using UnityEngine;

public class EnemyMageAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ProjectileMover _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;

    public void StartAttack()
    {
        _animator.SetBool("IsAttacking", true);
    }

    public void StopAttack()
    {
        _animator.SetBool("IsAttacking", false);
    }

    public void ShootProjectile()
    {
        if (_projectilePrefab != null && _projectileSpawnPoint != null)
        {
            ProjectileMover newProjectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
            Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
        }
    }
}
