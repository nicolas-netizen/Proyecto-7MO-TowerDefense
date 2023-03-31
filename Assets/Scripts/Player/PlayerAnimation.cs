using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnimation
{
    [SerializeField] private Animator _animator;
    
    public void ChangeVel(float value)
    {
        _animator.SetFloat("Velocity", value);
    }
}
