using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerState
{
    private Player _player;

    public void SetPlayer(Player player)
    {
        _player = player;
    }


    public void Idle()
    {
        _player.MovementController.Idle();
    }

    public void Run()
    {
        _player.MovementController.Run();
    }

    public void AbilityExpansive()
    {
        _player.KnightAbility.CooldownStart();
        _player.AnimationController.AbilityExpansive();
    }
    //public void Dash()
    //{
    //    _player.ChargeAbility.D();
    //}
}
