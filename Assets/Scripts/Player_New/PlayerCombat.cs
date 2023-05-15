using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCombat
{
    private Player _player;

    [Header("DAMAGES")]
    [SerializeField] private float _basicDamage;
    private bool _isAttacking;
    private AttackDir _attackDirection;

    public float BasicDamage { get => _basicDamage; set => _basicDamage = value; }
    public bool IsAttacking { get => _isAttacking; set => _isAttacking = value; }
    public AttackDir AttackDirection { get => _attackDirection; set => _attackDirection = value; }

    public void SetPlayer(Player player)
    {
        _player = player;
    }   
}
