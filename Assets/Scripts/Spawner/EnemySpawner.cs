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
        yield return new WaitForSeconds(spawnDelay);;
        }
}
