using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class EnemyM : MonoBehaviour
{
    [Header("GENERAL")]
    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;

    [Header("CHASE")]
    [SerializeField] private float _followSpeed = 3f;

    [Header("ATTACK")]
    [SerializeField] private float _attackRange = 2f;
    [SerializeField] private float _attackCooldown = 2f;

    [Header("ESCAPE")]
    [SerializeField] private float _escapeRange = 5f;

    private NodeEscape _lastNode;
    private NodeEscape _targetNode;
    private bool isEscaping = false;
    private void Start()
    {
        _agent.speed = _followSpeed;
    }

    private bool _movement;

    public bool Movement { get => _movement; set => _movement = value; }

    private void Update()
    {
        var escapeRangeColliders = Physics.OverlapSphere(transform.position, _escapeRange, _playerMask);

        if (escapeRangeColliders.Length > 0)
        {
            isEscaping = true; // Activar el modo de escape.
            Escape();
        }
        else
        {
            isEscaping = false; // Desactivar el modo de escape.

            var attackRangeColliders = Physics.OverlapSphere(transform.position, _attackRange, _playerMask);

            transform.DOLookAt(_player.position, 0.2f, AxisConstraint.Y);

            _targetNode = null;

            if (attackRangeColliders.Length <= 0) // SI NO ESTÁ CERCA DEL PLAYER
            {
                if (!_movement)
                {
                    _agent.speed = _followSpeed;
                    _agent.SetDestination(_player.position);
                    _animator.SetBool("Attack", false);
                }
            }
            else // SI ESTÁ CERCA DEL PLAYER
            {
                Attack();
            }
        }
        if (_movement)
        {
            _agent.speed = 0;
        }
    }

    public void Escape()
    {
        if (isEscaping)
        {
            _animator.SetBool("Attack", false);

            if (_targetNode == null)
            {
                LookForClosestEmptyNode();
            }
            else
            {

                if (!_movement)
                {
                    transform.DOLookAt(_targetNode.transform.position, 0.5f, AxisConstraint.Y);
                    _agent.speed = _followSpeed;
                    _agent.SetDestination(_targetNode.transform.position);

                }

                var a = new Vector3(transform.position.x, 0, transform.position.z);
                var b = new Vector3(_targetNode.transform.position.x, 0, _targetNode.transform.position.z);

                if (Vector3.Distance(a, b) <= 0.3f)
                {
                    _lastNode = _targetNode;
                    _targetNode = null;
                }
            }
        }
    }
    public void Attack()
    {
        _agent.SetDestination(transform.position);
        _animator.SetBool("Attack", true);
        // Aquí puedes agregar lógica para el ataque al jugador si estás en rango de ataque.
    }

    public void LookForClosestEmptyNode()
    {
        float distance = float.MaxValue;
        NodeEscape targetNode = null;

        if (_targetNode != null)
            _lastNode = _targetNode;

        foreach (var item in EnemyManager.Instance.EscapeNodes)
        {
            if (!item.CheckPlayerPosition() && item != _lastNode)
            {
                float distanceToNode = Vector3.Distance(transform.position, item.transform.position);
                if (Vector3.Distance(transform.position, item.transform.position) < distance)
                {
                    distance = distanceToNode;
                    targetNode = item;
                }
            }
        }

        _targetNode = targetNode;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _escapeRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_agent.destination, _escapeRange);
    }
}
