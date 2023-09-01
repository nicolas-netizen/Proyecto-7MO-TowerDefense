using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMageAnimationHandler : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyM _enemy;

    public void StartAttack()
    {
        _enemy.Movement = true;
    }

    public void StopAttack()
    {
        _enemy.Movement = false;
    }
}
