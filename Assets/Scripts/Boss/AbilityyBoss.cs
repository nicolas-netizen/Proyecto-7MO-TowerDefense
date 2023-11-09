using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityyBoss : MonoBehaviour
{
    [SerializeField] public float _activationRange = 10f;
    [SerializeField] public float _stunDuration = 3f;
    [SerializeField] public float _cooldownTime = 2f;

    private EnemyBossAnimationHandler animationHandler;
    private float lastAbilityTime;

    public GameObject stunEffectPrefab;

    private void Start()
    {
        animationHandler = GetComponent<EnemyBossAnimationHandler>();
        lastAbilityTime = -_cooldownTime;
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= _activationRange)
            {
                if (Time.time - lastAbilityTime >= _cooldownTime)
                {
                    ActivateAbility(player);
                }
            }
        }
    }

    private void ActivateAbility(GameObject player)
    {
        if (stunEffectPrefab != null)
        {
            GameObject stunInstance = Instantiate(stunEffectPrefab, player.transform.position, Quaternion.identity);
            Destroy(stunInstance, _stunDuration);
            animationHandler.StartAttack();
            StunManager.ApplyStunToPlayer(player.GetComponent<Player>(), _stunDuration);

            // No deshabilitar el componente, solo registra el tiempo del último uso de la habilidad
            lastAbilityTime = Time.time;
        }
    }
}
