using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Boss : MonoBehaviour, IDamageable
{
    [Header("General")]
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    [Header("Chase")]
    [SerializeField] private float followSpeed = 3f;

    [Header("Attack")]
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 2f;
    private float timerAttack;

    [Header("Escape")]
    [SerializeField] private float escapeRange = 5f;

    [SerializeField] private BossHealth bossHealth;
    [SerializeField] private EnemyVFX enemyVFX;
    [SerializeField] private BossRig bossRig;

    private NodeEscape lastNode;
    private NodeEscape targetNode;
    private bool isEscaping = false;

    private bool movement;

    public bool Movement { get => movement; set => movement = value; }
    public EnemyVFX EnemyVFX { get => enemyVFX; set => enemyVFX = value; }
    public NavMeshAgent Agent { get => agent; set => agent = value; }
    public BossRig BossRig { get => bossRig; set => bossRig = value; }
    public BossHealth BossHealth { get => bossHealth; set => bossHealth = value; }

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>().transform;
        bossHealth.SetEnemy(this);
    }

    private void Start()
    {
        agent.speed = followSpeed;
        bossHealth.ManualStart();
        bossRig.SetEnemy(this);
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (!animator.GetBool("Attack"))
        {
            timerAttack += Time.deltaTime;

            if (distanceToPlayer <= escapeRange)
            {
                isEscaping = true;
                Escape();
                animator.SetBool("Run", true);
            }
            else
            {
                isEscaping = false;

                if (distanceToPlayer > attackRange)
                {
                    animator.SetBool("Run", true);

                    if (!movement)
                    {
                        agent.speed = followSpeed;
                        agent.SetDestination(player.position);
                        animator.SetBool("Attack", false);
                    }
                }
                else
                {
                    animator.SetBool("Run", false);
                    Attack();
                }
            }

            if (movement)
            {
                agent.speed = 0;
            }
        }
    }

    public void Escape()
    {
        if (isEscaping)
        {
            animator.SetBool("Attack", false);

            if (targetNode == null)
            {
                LookForClosestEmptyNode();
            }
            else
            {
                if (!movement)
                {
                    transform.DOLookAt(targetNode.transform.position, 0.5f, AxisConstraint.Y);
                    if (agent != null)
                    {
                        agent.speed = followSpeed;
                        agent.SetDestination(targetNode.transform.position);
                    }
                }

                var a = new Vector3(transform.position.x, 0, transform.position.z);
                var b = new Vector3(targetNode.transform.position.x, 0, targetNode.transform.position.z);

                if (Vector3.Distance(a, b) <= 0.3f)
                {
                    lastNode = targetNode;
                    targetNode = null;
                }
            }
        }
    }

    public void Attack()
    {
        if (timerAttack > attackCooldown)
        {
            if (agent != null)
            {
                timerAttack = 0;
                agent.SetDestination(transform.position);
                animator.SetBool("Attack", true);
            }
        }
    }

    public void LookForClosestEmptyNode()
    {
        float distance = float.MaxValue;
        NodeEscape targetNode = null;

        if (targetNode != null)
            lastNode = targetNode;

        foreach (var item in EnemyManager.Instance.EscapeNodes)
        {
            if (!item.CheckPlayerPosition() && item != lastNode)
            {
                float distanceToNode = Vector3.Distance(transform.position, item.transform.position);
                if (distanceToNode < distance)
                {
                    distance = distanceToNode;
                    targetNode = item;
                }
            }
        }

        this.targetNode = targetNode;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, escapeRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(agent.destination, escapeRange);
    }

    public void TakeDamage(float mod, Vector3 dir)
    {
        bossHealth.UpdateHealth(mod);
    }

    public void TakeDamage(float mod)
    {
        bossHealth.UpdateHealth(mod);
    }

    public GameObject GetObject()
    {
        return gameObject;
    }
}
