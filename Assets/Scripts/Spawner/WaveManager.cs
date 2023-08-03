using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Wave> waves;
    public float timeBetweenWaves = 5f;

    private int currentWaveIndex = 0;
    private bool isSpawningWave = false;


    Coroutine _coroutineWave;

    public static WaveManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    private void Start()
    {
        _coroutineWave = StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);

        while (currentWaveIndex < waves.Count && !ObjetiveManager.Instance.GameIsOver)
        {
            Wave currentWave = waves[currentWaveIndex];
            isSpawningWave = true;

            for (int i = 0; i < currentWave.enemyCount; i++)
            {
                Vector3 spawnPos = transform.position + Random.insideUnitSphere * 5f;
                Instantiate(currentWave.enemyPrefab, spawnPos, Quaternion.identity);

                if (i < currentWave.enemyCount - 1)
                {
                    yield return new WaitForSeconds(currentWave.spawnDelay);
                }
            }

            while (GameObject.FindWithTag("Enemy") != null)
            {
                yield return null;
            }

            isSpawningWave = false;
            currentWaveIndex++;

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    public void GameOver()
    {
        StopCoroutine(_coroutineWave);
    }
}
