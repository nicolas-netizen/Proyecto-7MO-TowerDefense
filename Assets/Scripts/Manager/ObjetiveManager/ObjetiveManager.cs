using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetiveManager : MonoBehaviour
{
    [Header("DEBUG")]
    private int _countEnemiesAtEnd;
    [SerializeField] private int _enemiesAtEndMax;
    private bool _gameIsOver;
    private int _enemiesAtEnd;

    public static ObjetiveManager Instance;

    [SerializeField] private EnemySpawner _enemySpawner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        if (_enemySpawner == null)
        {
            Debug.LogError("EnemySpawner not found! Make sure you have assigned the EnemySpawner component to the ObjetciveManager script in the Inspector.");
            return;
        }

        UIManager.Instance.SetEnemyAtEndCounter(0, _enemiesAtEndMax);
    }


    private void Update()
    {
        if (_countEnemiesAtEnd < _enemiesAtEndMax)
            return;

        if (!_gameIsOver)
        {
            _gameIsOver = true;
        }
    }

    public void AddEnemyAtEnd()
    {
        if (_gameIsOver)
            return;

        _countEnemiesAtEnd++;
        _enemiesAtEnd++;

        UIManager.Instance.SetEnemyAtEndCounter(_countEnemiesAtEnd, _enemiesAtEndMax);

        if (_enemiesAtEnd >= _enemiesAtEndMax)
        {
            _gameIsOver = true;
            GameOver();
        }
    }

    public void GameOver()
    {
        _enemySpawner.StopSpawning();
        UIManager.Instance.FadeIn();
    }
}

