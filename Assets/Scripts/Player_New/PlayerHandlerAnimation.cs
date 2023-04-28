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
    public void OnComboEndo()
    {
        _player.PlayerCombo.OnComboEnd();
    }


}
