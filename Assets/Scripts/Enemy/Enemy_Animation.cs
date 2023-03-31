using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy_Animation
{

    [SerializeField] private Animator _animator;

    private Enemy _enemy;
    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }


    public void ManualUpdate()
    {
        if (_enemy.AiController.State == MovementState.Idle)
            _animator.SetFloat("Speed", 0, 0.1f,Time.deltaTime);

        if (_enemy.AiController.State == MovementState.Moving)
            _animator.SetFloat("Speed", 1, 0.1f, Time.deltaTime);

        if (_enemy.AiController.State == MovementState.Combat)
        {
            _animator.SetBool("Attack", true);
            _animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        }
        else
            _animator.SetBool("Attack", false);
    }
}
