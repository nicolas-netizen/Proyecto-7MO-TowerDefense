using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetiveManager : MonoBehaviour
{
    [SerializeField] private Player _player;

    [Header("DEBUG")]
    [SerializeField] private int _enemiesAtEndMax;

    private int _countEnemiesAtEnd;
    private bool _gameIsOver = false;
    [SerializeField] private Image _progressBar;

    private int _enemiesAtEnd;

    public static ObjetiveManager Instance;

    public bool GameIsOver { get => _gameIsOver; }

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
        if (_countEnemiesAtEnd >= _enemiesAtEndMax)
        {
            GameOver();
        }
        else if (_countEnemiesAtEnd <= _enemiesAtEndMax && WaveManager.Instance.AllWavesCompleted())
        {
            Win();
        }
    }

    public void AddEnemyAtEnd()
    {
        if (_gameIsOver)
            return;

        _countEnemiesAtEnd++;
        _enemiesAtEnd++;

        float progressPercentage = (float)_countEnemiesAtEnd / _enemiesAtEndMax;
        _progressBar.fillAmount = progressPercentage; // Actualizar la barra de progreso

        UIManager.Instance.SetEnemyAtEndCounter(_countEnemiesAtEnd, _enemiesAtEndMax);

        if (_countEnemiesAtEnd >= _enemiesAtEndMax)
        {
            GameOver();
        }
        else if (_countEnemiesAtEnd <= _enemiesAtEndMax && WaveManager.Instance.AllWavesCompleted())
        {
            Win();
        }
    }

    public void GameOver()
    {
        if (_gameIsOver == false)
        {
            _gameIsOver = true;
            Debug.Log("Game over");
            WaveManager.Instance.GameOver();
            CameraManager.Instance.GameOver();
            _player.InputController.BlockInputs();
            _player.AnimationController.Animator.SetTrigger("Praying");
        }
    }

    public void Win()
    {
        if (_gameIsOver == false)
        {
            _gameIsOver = true;
            Debug.Log("You win!");
            CameraManager.Instance.Win();
            _player.InputController.BlockInputs();
            _player.AnimationController.Animator.SetTrigger("Victory");
        }
    }
}
