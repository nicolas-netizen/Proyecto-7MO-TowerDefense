using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IWaveable
{

    [SerializeField] private EnemyChase _enemyChase;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private EnemyRig _enemyRig;
    [SerializeField] private EnemyVFX _enemyVFX;

    public CoinManager coinManager;
    public float coinDropChance = 0.5f;

    public EnemyChase EnemyChase { get => _enemyChase; set => _enemyChase = value; }
    public EnemyHealth EnemyHealth { get => _enemyHealth; set => _enemyHealth = value; }
    public EnemyRig EnemyRig { get => _enemyRig; set => _enemyRig = value; }
    public EnemyVFX EnemyVFX { get => _enemyVFX; set => _enemyVFX = value; }

    void Start()
    {
        _enemyChase.SetEnemy(this);
        _enemyHealth.SetEnemy(this);
        _enemyRig.SetEnemy(this);
        _enemyRig.ManualStart();
        _enemyHealth.ManualStart();
    }

    // Update is called once per frame
    void Update()
    {
        _enemyChase.ManualUpdate();
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _enemyChase.RangeChase);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndPoint"))
        {
            ObjetiveManager.Instance.AddEnemyAtEnd();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float mod, Vector3 dir)
    {
        _enemyHealth.UpdateHealth(-mod, dir);
    }

    public void TakeDamage(float mod)
    {
        _enemyHealth.UpdateHealth(-mod);
    }

    public GameObject GetObject()
    {
        return gameObject;
    }

    [SerializeField] private List<Node> _visitedNode;
    public void NextNode(Node nextNode, Node thisNode, List<Node> ignoreNextNodes)
    {
        if (!_visitedNode.Contains(thisNode))
        {
            foreach (var item in ignoreNextNodes)
            {
                _visitedNode.Add(item);
            }
            _visitedNode.Add(thisNode);
            _enemyChase.NextPoint = nextNode;
        }
    } 

    public void NextNodeMenu(Node nextNode)
    {
        _enemyChase.NextPoint = nextNode;
    }
}

