using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovement
{
    private Player _player;

    [SerializeField] private CharacterController _controller;

    [SerializeField] private float _speed = 2;

    private Vector3 movement;

    public Vector3 Movement { get => movement; set => movement = value; }

    public void ManualUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        movement = _player.transform.TransformDirection(movement);

        _controller.Move(movement * Time.deltaTime * _speed);
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }
}