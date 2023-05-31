using UnityEngine;

public class ChargeAbility : MonoBehaviour
{
    public float damage = 20f; // Daño causado por la habilidad
    public float knockbackForce = 10f; // Fuerza de empuje hacia atrás

    public void DefensiveCharge()
    {
        // Detectar los enemigos en el área frontal
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.forward, 3f); // Ajusta el radio según tus necesidades

        // Aplicar daño y empuje a los enemigos
        foreach (Collider hitCollider in hitColliders)
        {
            Enemy enemy = hitCollider.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Aplicar daño al enemigo
                enemy.TakeDamage(damage);

                // Empujar al enemigo hacia atrás
                Vector3 knockbackDirection = (enemy.transform.position - transform.position).normalized;
                enemy.ApplyKnockback(knockbackDirection, knockbackForce);
            }
        }
    }
}



