using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Enemy_Damage damage;
    [SerializeField] private Enemy_Health _healthController;
    [SerializeField] private AI_Enemy _aiController;
    [SerializeField] private Enemy_Animation _animationController;

    public Enemy_Animation AnimationController { get => _animationController; set => _animationController = value; }
    public AI_Enemy AiController { get => _aiController; set => _aiController = value; }

    private void Awake()
    {
        _animationController.SetEnemy(this);
        _healthController.SetEnemy(this);
        _aiController.SetEnemy(this);
    }

    void Start()
    {
        _healthController.ManualStart();
        _aiController.ManualStart();
    }

    private void Update()
    {
        _animationController.ManualUpdate();
        _aiController.ManualUpdate();
    }
}
