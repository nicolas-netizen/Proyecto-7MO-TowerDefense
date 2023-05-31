using UnityEngine;

public class ChargeAbility : MonoBehaviour
{
    public float damage = 20f; // Da�o causado por la habilidad
    public float knockbackForce = 10f; // Fuerza de empuje hacia atr�s

    public void DefensiveCharge()
    {
        // Detectar los enemigos en el �rea frontal
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.forward, 3f); // Ajusta el radio seg�n tus necesidades

        // Aplicar da�o y empuje a los enemigos
        foreach (Collider hitCollider in hitColliders)
        {
            Enemy enemy = hitCollider.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Aplicar da�o al enemigo
                enemy.TakeDamage(damage);

                // Empujar al enemigo hacia atr�s
                Vector3 knockbackDirection = (enemy.transform.position - transform.position).normalized;
                enemy.ApplyKnockback(knockbackDirection, knockbackForce);
            }
        }
    }
}



