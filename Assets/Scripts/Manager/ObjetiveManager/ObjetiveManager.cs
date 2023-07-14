using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetiveManager : MonoBehaviour
{
    [Header("DEBUG")]
    private int _countEnemiesAtEnd;
    [SerializeField] private int _enemiesAtEndMax;
    private bool _gameIsOver;

    public static ObjetiveManager Instance;

    [SerializeField] private EnemySpawner _enemySpawner; // Referencia al script EnemySpawner

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
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
        UIManager.Instance.SetEnemyAtEndCounter(_countEnemiesAtEnd, _enemiesAtEndMax);

        if (_countEnemiesAtEnd >= _enemiesAtEndMax)
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

