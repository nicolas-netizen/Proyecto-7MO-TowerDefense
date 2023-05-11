using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyRig
{
    //[SerializeField] public Animator _animator;
    //[SerializeField] public Rigidbody _rb;

    [SerializeField] private GameObject _rig;
    [SerializeField] private Collider _mainCollider;
    [SerializeField] private Collider _player;

    private NavMeshAgent _agent;
    private Enemy _enemy;

    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
        _agent = enemy.EnemyChase.Agent;
    }

    Collider[] ragDollCols;
    Rigidbody[] ragDollRb;
    public void ManualStart()
    {
        ragDollCols = _rig.GetComponentsInChildren<Collider>(); 
        ragDollRb = _rig.GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
        

    }

    public void ActiveRagdoll()
    {
        //_animator.enabled = false;
        //_rb.constraints = RigidbodyConstraints.None;
        _agent.isStopped = true;
        _agent.speed = 0;

        _rig.GetComponent<Animator>().enabled = false;
        foreach (var item in ragDollCols)
        {
            item.gameObject.layer = LayerMask.NameToLayer("Ignore");
            item.enabled = true;
        }

        foreach (var item in ragDollRb)
        {
            item.isKinematic = false;
        }

        _mainCollider.enabled = false;
        _enemy.GetComponent<Rigidbody>().isKinematic = true;

    }


    public void DisableRagdoll()
    {
        foreach (var item in ragDollCols)
        {
            item.enabled = false;
        }

        foreach (var item in ragDollRb)
        {
            item.isKinematic = true;
        }

        _rig.GetComponent<Animator>().enabled = true;
        _mainCollider.enabled = true;
        _enemy.GetComponent<Rigidbody>().isKinematic = false;
    }

}

