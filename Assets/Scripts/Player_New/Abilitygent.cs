using UnityEngine;

public class Abilitygent : MonoBehaviour
{
    public float attackRange = 2f;
    public int attackDamage = 10;
    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("SpecialAttack");

            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange);

            foreach (Collider enemy in hitEnemies)
            {
                //if (enemy.CompareTag("Enemy"))
                //{
                //    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                //}
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}





