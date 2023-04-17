using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatState
{
    Passive,
    Combat
}

[System.Serializable]
public class PlayerCombat
{
    private Player _player;

    [SerializeField] private CombatState _combatState;

    public CombatState CombatState { get => _combatState; set => _combatState = value; }

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void ChangeState(CombatState state)
    {
        _combatState = state;
    }
    

}
