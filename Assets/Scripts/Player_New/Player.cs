using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movementController;
    [SerializeField] private PlayerInput _inputController;
    [SerializeField] private PlayerState _stateController;
    [SerializeField] private PlayerRotation _rotationController;

    public PlayerMovement MovementController { get => _movementController; set => _movementController = value; }
    public PlayerInput InputController { get => _inputController; set => _inputController = value; }
    public PlayerState StateController { get => _stateController; set => _stateController = value; }
    public PlayerRotation RotationController { get => _rotationController; set => _rotationController = value; }

    void Start()
    {
        _movementController.SetPlayer(this);
        _inputController.SetPlayer(this);
        _stateController.SetPlayer(this);
        _rotationController.SetPlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
        _inputController.ManualUpdate();
    }
}
