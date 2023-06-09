using UnityEngine;

public class Ability2 : MonoBehaviour
{
    [SerializeField] private ParticleSystem _lightningParticles;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private KeyCode _activationKey = KeyCode.R;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _animationTrigger = "AbilityTrigger";

    private void Update()
    {
        if (Input.GetKeyDown(_activationKey))
        {
            ActivateAbility();
        }
    }

    private void ActivateAbility()
    {
        _lightningParticles.Play();
        _animator.SetTrigger(_animationTrigger);

        // Detectar los objetos afectados por el rayo
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _lightningParticles.main.startLifetime.constant);

        // Aplicar daño a los objetos afectados
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                Enemy enemy = hitCollider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Vector3 dir = hitCollider.transform.position - transform.position;
                    enemy.TakeDamage(_damage, dir);
                }
            }
        }
    }
}
