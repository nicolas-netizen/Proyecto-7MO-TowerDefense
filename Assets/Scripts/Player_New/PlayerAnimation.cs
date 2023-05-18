using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnimation
{
    private Player _player;
    [SerializeField]private Animator _animator;


    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void ManualUpdate()
    {
        if (_player.MovementController.MovementState == MovementState.Idle)
        {
            _animator.SetFloat("Speed", 0, 0.05f, Time.deltaTime);
        }
        else
        {
            if (_player.MovementController.MovementState == MovementState.Running)
                _animator.SetFloat("Speed", 2, 0.1f, Time.deltaTime);
        }
    }

    public void AbilityExpansive()
    {
        _animator.SetTrigger("AbilityTrigger");
    }
}
