using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[System.Serializable]
public class EnemyChase
{
    [Header("MOVEMENT")]
    private float _currentSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _rangeChase;
    [SerializeField] private LayerMask _playerMask;

    [Header("ATTACH")]
    private Transform _target;
    [SerializeField] private Node _nextPoint;
    [SerializeField] private NavMeshAgent _agent;

    private NavMeshPath _path;
    private Enemy _enemy;

    public float RangeChase { get => _rangeChase;}
    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public Node NextPoint { get => _nextPoint; set => _nextPoint = value; }

    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
        _path = new NavMeshPath();
        _currentSpeed = _runSpeed;
        _target = EnemyManager.Instance.Player.transform;
        _nextPoint = EnemyManager.Instance.GetStartNode();
    }

    public void ManualUpdate()
    {
        if(_agent != null)
        {
            _agent.speed = _currentSpeed;

            //var checkPlayer = Physics.OverlapSphere(_enemy.transform.position, _rangeChase, _playerMask);

            //if (checkPlayer.Length > 0 && _agent.CalculatePath(_target.position, _path))
            //{
            //    _agent.SetDestination(_target.position);
            //}
            //else
            //{
            if (_agent != null && _agent.isActiveAndEnabled)
            {
                _agent.SetDestination(_nextPoint.transform.position);
            }

            //}
        }
    }
}
