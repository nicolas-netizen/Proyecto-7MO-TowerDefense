using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float mod, Vector3 dir);
    GameObject GetObject();
}
