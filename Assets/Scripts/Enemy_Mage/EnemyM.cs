using UnityEngine;

public class EnemyM : MonoBehaviour
{
    public Transform player;
    [SerializeField] public float _followSpeed = 3f;
    [SerializeField] public float _attackRange = 2f;
    [SerializeField] public float _attackCooldown = 2f;
    [SerializeField] public float _escapeRange = 5f;

    private float attackTimer;
    private bool isAttacking;

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= _attackRange)
        {
            if (attackTimer <= 0f)
            {
                Attack();
            }
            else
            {
                if (!isAttacking)
                {
                    EnterIdleCombat();
                }
            }
        }
        else if (distanceToPlayer <= _escapeRange)
        {
            Escape();
        }
        else
        {
            FollowPlayer();
        }

        attackTimer -= Time.deltaTime;
    }

    private void FollowPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * _followSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        Debug.Log("Attacking!");
        isAttacking = true;
        attackTimer = _attackCooldown;
    }

    private void EnterIdleCombat()
    {
        Debug.Log("Entering idle combat");
        isAttacking = false;
    }

    private void Escape()
    {
        Debug.Log("Escaping!");
        isAttacking = false;
    }
}
