using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movementController;
    [SerializeField] private PlayerAnimation _animationController;
    [SerializeField] private PlayerHealth _healthController;

    public PlayerAnimation AnimationController { get => _animationController; set => _animationController = value; }
    public PlayerHealth HealthController { get => _healthController; set => _healthController = value; }

    private void Awake()
    {
        _movementController.SetPlayer(this);
    }

    void Start()
    {
        _movementController.ManualStart();
        _healthController.ManualStart();
    }

    // Update is called once per frame
    void Update()
    {
        _movementController.ManualUpdate();
        _animationController.ChangeVel(_movementController.Movement.magnitude);
    }   
}
