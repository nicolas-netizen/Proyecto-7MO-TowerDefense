using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class InvocationSkill : MonoBehaviour
{
    [SerializeField] public GameObject _enemyPrefab;
    [SerializeField] public Transform _castPoint;
    [SerializeField] public float _castRange = 5f;
    [SerializeField] public float _cooldown = 10f;

    private bool isOnCooldown = false;

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distanceToPlayer = Vector3.Distance(player.transform.position, _castPoint.position);

        if (distanceToPlayer <= _castRange && !isOnCooldown)
        {
            CastSkill();
        }
    }

    private void CastSkill()
    {
        StartCoroutine(InvokeEnemies());
    }

    private IEnumerator InvokeEnemies()
    {
        isOnCooldown = true;
        Collider[] colliders = Physics.OverlapSphere(_castPoint.position, _castRange);

        for (int i = 0; i < 5; i++)
        {
            Vector3 randomPosition = RandomPositionInsideRange(_castPoint.position, _castRange);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(_enemyPrefab, randomPosition, spawnRotation);
        }

        yield return new WaitForSeconds(_cooldown);

        isOnCooldown = false;
    }

    private Vector3 RandomPositionInsideRange(Vector3 center, float range)
    {
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += center;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, range, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
