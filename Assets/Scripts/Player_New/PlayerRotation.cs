using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerRotation
{
    private Player _player;

    [SerializeField] private float _turnSpeed;
    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void SetForward(Vector3 forward)
    {
        _player.transform.forward = forward;
    }

    public void SmoothForward(Vector3 vec)
    {
        Quaternion targetRotation = Quaternion.LookRotation(vec - _player.transform.position);
       _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation, targetRotation, Time.deltaTime * _turnSpeed);
    }
}
