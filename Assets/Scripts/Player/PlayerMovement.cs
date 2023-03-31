using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovement
{
    private Player _player;

    public void ManualStart()
    {
        
    }
    [SerializeField]private float _speed = 2;

    private Vector3 movement;

    public Vector3 Movement { get => movement; set => movement = value; }

    public void ManualUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical"); 

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical); 

        _player.transform.Translate(movement * _speed * Time.deltaTime, Space.World); 
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }
}
