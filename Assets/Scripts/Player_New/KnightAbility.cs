using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAbility : MonoBehaviour
{

    [SerializeField] private Player _player;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float cooldown;
    [SerializeField] private GameObject sword;
    [SerializeField] private bool isCooldown = false;
    [SerializeField] private Animator animator;

    void Update()
    {
        if (!isCooldown && Input.GetKeyDown(KeyCode.F))
        {
            _player.StateController.AbilityExpansive();
        }
    }

    public void ActivateAbility()
    {
        if (sword != null)
        {
            sword.SetActive(true);

            CameraShake cameraShake = Camera.main.GetComponent<CameraShake>();
            if (cameraShake != null)
            {
                cameraShake.Shake(cameraShake.ShakeMagnitudeAbility);
            }
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Enemy"))
                {
                    Enemy enemy = hitCollider.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        Vector3 dir = hitCollider.transform.position - transform.position;
                        enemy.TakeDamage(damage, dir);
                    }
                }
            }
        }
    }

    public void CooldownStart()
    {
        StartCoroutine(CooldownRoutine());
    }

    IEnumerator CooldownRoutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isCooldown = false;
    }
}


