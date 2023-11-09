using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class InvocationSkill : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
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
            int randomIndex = Random.Range(0, _enemyPrefabs.Length);
            GameObject selectedPrefab = _enemyPrefabs[randomIndex];

            Vector3 randomPosition = RandomPositionInsideRange(_castPoint.position, _castRange);
            Quaternion spawnRotation = Quaternion.identity;

            Instantiate(selectedPrefab, randomPosition, spawnRotation);
        }

        yield return new WaitForSeconds(_cooldown);

        isOnCooldown = false;
    }

    private Vector3 RandomPositionInsideRange(Vector3 center, float range)
    {
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += center;
        NavMeshHit hit;
        Vector3 finalPosition = center; 
        int maxAttempts = 10;
        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            Vector3 randomPosition = randomDirection + Random.insideUnitSphere * range;
            if (NavMesh.SamplePosition(randomPosition, out hit, range, 1))
            {
                finalPosition = hit.position;
                break;
            }
        }

        return finalPosition;
    }

}
