using System.Collections;
using UnityEngine;

public class Ability2 : MonoBehaviour
{
    [SerializeField] private float _duration = 3f;
    [SerializeField] private float _tickInterval = 0.5f;
    [SerializeField] private float _damagePerTick = 10f;

    private bool _isAbilityActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && !_isAbilityActive)
        {
            ActivateAbility();
        }
    }

    private void ActivateAbility()
    {
        StartCoroutine(StartAbility());
    }

    private IEnumerator StartAbility()
    {
        _isAbilityActive = true;


        float elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            ApplyDamageToEnemies();

            yield return new WaitForSeconds(_tickInterval);
            elapsedTime += _tickInterval;
        }

        _isAbilityActive = false;
    }

    private void ApplyDamageToEnemies()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, /*radius*/ 5f);

        foreach (Collider collider in colliders)
        {

            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_damagePerTick);
            }
        }
    }
}



