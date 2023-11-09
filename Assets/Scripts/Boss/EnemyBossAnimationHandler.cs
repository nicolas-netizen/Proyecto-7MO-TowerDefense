using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBossAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void StartAttack()
    {
        _animator.SetBool("AttackBoss", true);
        _animator.SetBool("Walk", false);
    }

    public void StopAttack()
    {
        _animator.SetBool("AttackBoss", false);
        _animator.SetBool("Walk", true);
    }
}
