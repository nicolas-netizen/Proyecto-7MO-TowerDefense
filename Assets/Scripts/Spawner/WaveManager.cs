using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;

    [System.Serializable]
    public class EnemyInfo
    {
        public GameObject enemyPrefab;
        public int enemyCount;
    }

    [System.Serializable]
    public class Wave
    {
        public List<EnemyInfo> enemies;
        public float spawnDelay;
    }

    public List<Wave> waves;
    public float timeBetweenWaves = 5f;

    private int currentWaveIndex = 0;
    private bool isSpawningWave = false;
    private Coroutine _coroutineWave;

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

            foreach (var enemyInfo in currentWave.enemies)
            {
                for (int i = 0; i < enemyInfo.enemyCount; i++)
                {
                    Vector3 spawnPos = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position + Random.insideUnitSphere * 5f;

                    Instantiate(enemyInfo.enemyPrefab, spawnPos, Quaternion.identity);

                    if (i < enemyInfo.enemyCount - 1)
                    {
                        yield return new WaitForSeconds(currentWave.spawnDelay);
                    }
                }
            }

            while (FindObjectsOfType<Enemy>().Length != 0)
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
    public bool AllWavesCompleted()
    {
        return currentWaveIndex >= waves.Count;
    }
}
