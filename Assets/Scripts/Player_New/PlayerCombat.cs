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

    public float BasicDamage { get => _basicDamage; set => _basicDamage = value; }
    public bool IsAttacking { get => _isAttacking; set => _isAttacking = value; }

    public void SetPlayer(Player player)
    {
        _player = player;
    }

   
}
