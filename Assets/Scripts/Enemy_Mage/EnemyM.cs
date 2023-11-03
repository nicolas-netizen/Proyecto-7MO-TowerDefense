using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class EnemyM : MonoBehaviour, IDamageable
{
    [Header("GENERAL")]
    [SerializeField] private Transform _player;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;

    [Header("CHASE")]
    [SerializeField] private float _followSpeed = 3f;

    [Header("ATTACK")]
    [SerializeField] private float _attackRange = 2f;
    [SerializeField] private float _attackCooldown = 2f;
    private float _timerAttack;

    [Header("ESCAPE")]
    [SerializeField] private float _escapeRange = 5f;

    [SerializeField] private EnemyMhealth _enemyMHealth;
    [SerializeField] private EnemyVFX _enemyVFX;
    [SerializeField] private EnemyMRig _enemyRig;

    private NodeEscape _lastNode;
    private NodeEscape _targetNode;
    private bool isEscaping = false;

    private bool _movement;

    public bool Movement { get => _movement; set => _movement = value; }
    public EnemyMhealth EnemyMHealth { get => _enemyMHealth; set => _enemyMHealth = value; }
    public EnemyVFX EnemyVFX { get => _enemyVFX; set => _enemyVFX = value; }
    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public EnemyMRig EnemyRig { get => _enemyRig; set => _enemyRig = value; }

    private void Awake()
    {
        _player = GameObject.FindObjectOfType<Player>().transform;
        _enemyMHealth.SetEnemy(this);
    }

    private void Start()
    {
        _agent.speed = _followSpeed;
        _enemyMHealth.ManualStart();
        _enemyRig.SetEnemy(this);
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

        if (!_animator.GetBool("Attack"))
        {
            _timerAttack += Time.deltaTime;

            if (distanceToPlayer <= _escapeRange)
            {
                isEscaping = true; // Activa el modo de escape.
                Escape();
                _animator.SetBool("Run", true);
            }
            else
            {
                isEscaping = false; // Desactiva el modo de escape.

                if (distanceToPlayer > _attackRange) 
                {
                    _animator.SetBool("Run", true);

                    if (!_movement)
                    {
                        _agent.speed = _followSpeed;
                        _agent.SetDestination(_player.position);
                        _animator.SetBool("Attack", false);
                    }
                }
                else 
                {
                    _animator.SetBool("Run", false);
                    Attack();
                }
            }

            if (_movement)
            {
                _agent.speed = 0;
            }
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
                    if (_agent != null)
                    {
                        _agent.speed = _followSpeed;
                        _agent.SetDestination(_targetNode.transform.position);
                    }
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
        if (_timerAttack > _attackCooldown)
        {
            if (_agent != null)
            {
                _timerAttack = 0;
                _agent.SetDestination(transform.position);
                _animator.SetBool("Attack", true);
            }
        }
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

    public void TakeDamage(float mod, Vector3 dir)
    {
        _enemyMHealth.UpdateHealth(mod);
    }

    public void TakeDamage(float mod)
    {
        _enemyMHealth.UpdateHealth(mod);
    }

    public GameObject GetObject()
    {
        return gameObject;
    }
}
