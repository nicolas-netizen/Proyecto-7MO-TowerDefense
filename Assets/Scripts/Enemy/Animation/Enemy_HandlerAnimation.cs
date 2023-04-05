using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HandlerAnimation : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    
    public void DesactiveAttack()
    {
        _enemy.DamageController.IsAttacking = false;
    }

    public void ActiveAttack()
    {
        _enemy.DamageController.IsAttacking = true;
    }
}
