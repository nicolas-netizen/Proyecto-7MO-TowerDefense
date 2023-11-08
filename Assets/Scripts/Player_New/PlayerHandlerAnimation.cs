using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandlerAnimation : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    public void StartCombo()
    {
        _player.PlayerCombo.OnAttack();
    }

    public void ComboMiddle()
    {
        _player.PlayerCombo.OnComboMiddle();
    }

    public void OnComboEndo()
    {
        _player.PlayerCombo.OnComboEnd();
    }

    public void StartAttacking()
    {
        _player.PlayerCombat.IsAttacking = true;
        //_player.PlayerVFX.Slash();
    }

    public void StopAttacking()
    {
        _player.PlayerCombat.IsAttacking = false;
    }

    public void AttackSideLeft()
    {
        _player.PlayerCombat.AttackDirection = AttackDir.Left;
    }

    public void AttackSideRight()
    {
        _player.PlayerCombat.AttackDirection = AttackDir.Right;
    }

    public void ActivateExpansiveAbility()
    {
        _player.KnightAbility.ActivateAbility();
        _player.ToonEXplot1.Play();
        _player.PlayerVFX.Ground();
        _player.PlayerVFX.Escud();
    }

    public void StartExpansive()
    {
        _player.InputController.BlockInputs();
    }

    public void StopExpansive()
    {
        _player.InputController.UnlockInputs();
    }

    public void SFX_Slash()
    {
        _player.AudioSlash.Play();
    }
}
