using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwordOwner
{
    GameObject GetOwner();
    float GetDamage();
    bool CheckAttacking();
}
