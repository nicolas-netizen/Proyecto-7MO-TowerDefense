using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Speeds
{
    public float idleTransition;

    public float walkSpeed;
    public float walkTransition;

    public float runSpeed;
    public float runTransition;
}

public enum MovementState
{
    Idle,
    Running
}

public enum GroundedState
{
    Ground,
    Air
}

[System.Serializable]
public class PlayerMovement
{

    [Header("SPEEDS")]
    [SerializeField] private Speeds _speeds;
    [SerializeField] private MovementState _movementState;

    Vector3 vel;

    [Header("PARAMS")]
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _rayDistance = 0.5f;

    [Header("ATTACH")]
    [SerializeField] private CharacterController _controller;
    [SerializeField] private GameObject _groundChecker;

    [Header("DEBUG")]
    [SerializeField] private bool _isGrounded;
    [SerializeField] private float _currentSpeed;

    private Player _player;


    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void ManualStart()
    {
        _currentSpeed = 0;
    }

    public void ManualUpdate()
    {
        Gravity();
        GroundCheck();
    }

    public void Gravity()
    {
        vel.y += _gravity * Time.deltaTime;
        _controller.Move(vel * Time.deltaTime);
    }

    public void GroundCheck()
    {
        _isGrounded = Physics.Raycast(_groundChecker.transform.position, Vector3.down, _rayDistance, LayerMask.GetMask("Ground"));
        if (_isGrounded)
        {
            if(vel.y < 0)
                vel.y = 0f;

            //_groundedState = GroundedState.Ground;
        }
        else
        {
            //_groundedState = GroundedState.Air;
        }
    }

    Vector3 camRel;
    public void Move(Vector3 vector)
    {

            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;

            forward.y = 0;
            right.y = 0;

            forward = forward.normalized;
            right = right.normalized;

            Vector3 forwardRelative = vector.z * forward;
            Vector3 rightRelative = vector.x * right;

            camRel = forwardRelative + rightRelative;

            _controller.Move(camRel * Time.deltaTime * _currentSpeed);
    
            _player.RotationController.SetForward(camRel);
    }
    #region STATES
    private float velocity;

    public MovementState MovementState { get => _movementState; set => _movementState = value; }
    public CharacterController Controller { get => _controller; set => _controller = value; }

    public void Idle()
    {
        _currentSpeed = Mathf.SmoothDamp(_currentSpeed, 0, ref velocity, _speeds.idleTransition);
        _movementState = MovementState.Idle;
    }

    public void Run()
    {
        _currentSpeed = Mathf.SmoothDamp(_currentSpeed, _speeds.runSpeed, ref velocity, _speeds.runTransition);
        _movementState = MovementState.Running;
    }
    #endregion


}
