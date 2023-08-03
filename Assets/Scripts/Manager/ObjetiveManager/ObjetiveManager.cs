using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetiveManager : MonoBehaviour
{
    [Header("DEBUG")]
    private int _countEnemiesAtEnd;
    [SerializeField] private int _enemiesAtEndMax;
    private bool _gameIsOver = false;
    private int _enemiesAtEnd;

    public static ObjetiveManager Instance;

    public bool GameIsOver { get => _gameIsOver;}

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

        GameOver();
    }

    public void AddEnemyAtEnd()
    {
        if (_gameIsOver)
            return;

        _countEnemiesAtEnd++;
        _enemiesAtEnd++;

        UIManager.Instance.SetEnemyAtEndCounter(_countEnemiesAtEnd, _enemiesAtEndMax);
    }

    public void GameOver()
    {
        if (_gameIsOver == false)
        {
            _gameIsOver = true;
            Debug.Log("Game over");
            WaveManager.Instance.GameOver();
        }
    }
}

