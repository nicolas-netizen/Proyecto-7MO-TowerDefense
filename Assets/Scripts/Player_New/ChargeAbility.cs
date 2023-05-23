using UnityEngine;

public class ChargeAbility : MonoBehaviour
{
    public float chargeSpeed = 10f;
    public float chargeDuration = 1f;
    public float chargeCooldown = 5f;
    public float damage = 10f;
    public float knockbackForce = 100f;
    public GameObject chargeEffectPrefab; // Prefab del efecto de carga

    private Rigidbody rb;
    private bool isCharging = false;
    private bool isCooldown = false;
    private GameObject chargeEffect; // Referencia al efecto de carga actual

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isCooldown && Input.GetKeyDown(KeyCode.R))
        {
            ActivateAbility();
        }
    }

    private void FixedUpdate()
    {
        if (isCharging)
        {
            rb.velocity = transform.forward * chargeSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCharging && other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                Vector3 knockbackDirection = other.transform.position - transform.position;
                knockbackDirection.Normalize();
                enemy.TakeDamage(damage, knockbackDirection);
            }
        }
    }

    private void ActivateAbility()
    {
        isCharging = true;

        // Crear el efecto de carga
        chargeEffect = Instantiate(chargeEffectPrefab, transform.position, Quaternion.identity);

        // Iniciar la duración de la carga
        Invoke("StopCharging", chargeDuration);
    }

    private void StopCharging()
    {
        isCharging = false;
        rb.velocity = Vector3.zero;

        // Destruir el efecto de carga
        Destroy(chargeEffect);

        // Iniciar la rutina de enfriamiento de la habilidad
        StartCoroutine(CooldownRoutine());
    }

    private System.Collections.IEnumerator CooldownRoutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(chargeCooldown);
        isCooldown = false;
    }
}



