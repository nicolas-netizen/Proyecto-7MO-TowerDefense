using UnityEngine;

public class BlastWave : MonoBehaviour
{
    public ParticleSystem blastParticlesPrefab;
    public float blastRadius = 5f;
    public float blastForce = 10f;

    void Start()
    {
        CreateBlastParticles();
    }

    void CreateBlastParticles()
    {
        ParticleSystem blastParticles = Instantiate(blastParticlesPrefab, transform.position, Quaternion.identity);
        blastParticles.Play();

        // Aplicar fuerza a los objetos dentro del radio de la onda expansiva
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Calcular la dirección y la intensidad de la fuerza
                Vector3 direction = (rb.transform.position - transform.position).normalized;
                float distance = Vector3.Distance(rb.transform.position, transform.position);
                float falloff = 1f - Mathf.Clamp01(distance / blastRadius);
                float force = blastForce * falloff;

                // Aplicar la fuerza al objeto
                rb.AddForce(direction * force, ForceMode.Impulse);
            }
        }

        // Destruir el sistema de partículas después de un tiempo
        Destroy(blastParticles.gameObject, blastParticles.main.duration);
    }
}
