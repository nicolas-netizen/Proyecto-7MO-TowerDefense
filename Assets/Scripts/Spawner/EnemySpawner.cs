using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay = 1f;
    [SerializeField] private float spawnRadius = 5f;
    [SerializeField] private int _spawnAtSameTime;

        private bool isSpawning = false;

        public void SpawnEnemy(GameObject enemyPrefab, int enemyCount)
        {
            StartCoroutine(SpawnEnemies(enemyPrefab, enemyCount));
        }

        private IEnumerator SpawnEnemies(GameObject enemyPrefab, int enemyCount)
        {
            isSpawning = true;

            for (int i = 0; i < enemyCount; i++)
            {
                for (int j = 0; j < _spawnAtSameTime; j++)
                {
                    if (!isSpawning)
                        yield break;

                    Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
                    Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                }
                yield return new WaitForSeconds(spawnDelay);
            }

            isSpawning = false;
        }

        public void StopSpawning()
        {
            isSpawning = false;
        }
}
