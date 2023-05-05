using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]public GameObject _enemyprefab;
    [SerializeField] public int _maxEnemies = 10;
    [SerializeField] public float _spawnDelay = 1f;
    [SerializeField] public float _spawnRadius = 5f;

    private int enemyCount = 0;

    private void Start() {
        InvokeRepeating("SpawnEnemy", 0f, _spawnDelay);
    }
    public void SpawnEnemy()
    {
        if (enemyCount < _maxEnemies)
        {
            Vector3 spawnPos = transform.position + Random.insideUnitSphere * _spawnRadius;
            Instantiate(_enemyprefab, spawnPos, Quaternion.identity);
            enemyCount++;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("enemyspawn"))
        {
            if (enemyCount < _maxEnemies)
            {
                SpawnEnemy();
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, _spawnRadius);
    }
}
    
     
