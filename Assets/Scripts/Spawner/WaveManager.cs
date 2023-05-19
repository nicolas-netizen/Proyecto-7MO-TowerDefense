using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public List<Wave> waves;
    public float timeBetweenWaves = 5f;

    private int currentWaveIndex = 0;
    private bool isSpawningWave = false;

    private bool _firstFlag;
    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        if (_firstFlag)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        
        _firstFlag = true;
        while (currentWaveIndex < waves.Count)
        {
            Wave currentWave = waves[currentWaveIndex];
            isSpawningWave = true;

            enemySpawner.SpawnEnemy(currentWave.enemyPrefab, currentWave.enemyCount);

            while (enemySpawner.IsSpawning)
            {
                yield return null;
            }

            isSpawningWave = false;
            currentWaveIndex++;

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}


