using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movementController;
    [SerializeField] private PlayerAnimation _animationController;
    [SerializeField] private PlayerHealth _healthController;
    [SerializeField] private PlayerRotation _rotationController;

    public PlayerAnimation AnimationController { get => _animationController; set => _animationController = value; }
    public PlayerHealth HealthController { get => _healthController; set => _healthController = value; }


    private void Awake()
    {
        _movementController.SetPlayer(this);
        _rotationController.SetPlayer(this);
        _healthController.SetPlayer(this);
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        _healthController.ManualStart();
    }

    // Update is called once per frame
    void Update()
    {
        _rotationController.ManualUpdate();
        _movementController.ManualUpdate();
        _healthController.ManualUpdate();
        _animationController.ChangeVel(_movementController.Movement.magnitude);
    }
}
