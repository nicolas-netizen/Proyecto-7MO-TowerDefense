using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WavaIn : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public int initialEnemyCount = 1;
    public int enemyCountIncrease = 1;
    public float spawnInterval = 1.0f;

    private int currentWave = 0;
    private int enemiesRemaining;
    private bool isSpawningWave = false;

    private void Start()
    {
        StartCoroutine(StartWaves());
    }

    IEnumerator StartWaves()
    {
        yield return new WaitForSeconds(timeBetweenWaves);

        while (true) // Repetir oleadas infinitamente
        {
            currentWave++;
            waveText.text = "Oleada " + currentWave;
            waveText.fontSize = 36;
            waveText.color = Color.yellow;

            int waveEnemyCount = initialEnemyCount + (currentWave - 1) * enemyCountIncrease;

            for (int i = 0; i < waveEnemyCount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnInterval);
            }

            // Esperar hasta que todos los enemigos sean derrotados
            while (enemiesRemaining > 0)
            {
                yield return null;
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemy()
    {
        enemiesRemaining++;
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void EnemyDefeated()
    {
        enemiesRemaining--;

        if (enemiesRemaining <= 0 && !isSpawningWave)
        {
            isSpawningWave = false;
            StartCoroutine(StartWaves());
        }
    }
}
