using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackDir
{
    Right,
    Left
}

public interface ISwordOwner
{
    GameObject GetOwner();
    float GetDamage();
    bool CheckAttacking();
    AttackDir CheckAttackDir();
    
}
