using UnityEngine;

public class ChargeAbility : MonoBehaviour
{
    [SerializeField]
    private float _attackDamage = 10f;
    [SerializeField]
    private float _attackRange = 2f;
    [SerializeField]
    private LayerMask _enemyLayer;

    private bool isAttacking = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(PerformAttack());
        }
    }

    System.Collections.IEnumerator PerformAttack()
    {
        isAttacking = true;
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, _attackRange, _enemyLayer);

        foreach (Collider enemyCollider in hitEnemies)
        {
            Enemy enemy = enemyCollider.GetComponent<Enemy>();
            if (enemy != null)
            {
                Vector3 dir = enemy.transform.position - transform.position;
                enemy.TakeDamage(_attackDamage, dir);
            }
        }

        yield return new WaitForSeconds(0.5f); 

        isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
