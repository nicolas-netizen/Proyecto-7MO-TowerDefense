using UnityEngine;

public class EnemyMageAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ProjectileMover _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private float _projectileSpeed = 10f;

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

            if (projectileRigidbody != null)
            {
                projectileRigidbody.velocity = _projectileSpawnPoint.forward * _projectileSpeed;
            }
        }
    }
}
