using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MovementState
{
    Idle,
    Moving,
    Combat
}


[System.Serializable]
public class AI_Enemy
{
    [SerializeField] private Transform _objetivo;
    [SerializeField] private float _velocidad;
    [SerializeField] private NavMeshAgent _ai;

    [SerializeField] private MovementState _state;

    public MovementState State { get => _state; set => _state = value; }

    private Enemy _enemy;
    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void ManualStart()
    {
        _ai.SetDestination(_objetivo.position);
    }

    public void ManualUpdate()
    {
        _ai.SetDestination(_objetivo.position);


        if (_ai.stoppingDistance < _ai.remainingDistance)
        {
            _ai.speed = _velocidad;
            _ai.SetDestination(_objetivo.position);
            _state = MovementState.Moving;
        } else
        {
            _state = MovementState.Combat;
        }

    }
}
