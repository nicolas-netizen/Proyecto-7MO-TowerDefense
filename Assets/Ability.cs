using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name;
    public float _cooldownTime;
    public float _activateTime;
    
    public virtual void Activate()
    {

    }
}
