using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyMRig
{
    //[SerializeField] public Animator _animator;
    //[SerializeField] public Rigidbody _rb;

    [SerializeField] private GameObject _rig;
    [SerializeField] private GameObject _hips;
    [SerializeField] private Collider _mainCollider;
    [SerializeField] private Collider _player;
    [SerializeField] public float magnitude = 1000f;

    private NavMeshAgent _agent;
    private EnemyM _enemy;

    public void SetEnemy(EnemyM enemy)
    {
        _enemy = enemy;
        _agent = enemy.Agent;
        ManualStart();
    }

    Collider[] ragDollCols;
    Rigidbody[] ragDollRb;
    public void ManualStart()
    {
        ragDollCols = _rig.GetComponentsInChildren<Collider>();
        ragDollRb = _rig.GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();


    }

    public void ActiveRagdoll(Vector3 dir)
    {
        _agent.isStopped = true;
        _agent.speed = 0;
        _enemy.Agent = null;

        _rig.GetComponent<Animator>().enabled = false;
        foreach (var item in ragDollCols)
        {
            item.gameObject.layer = LayerMask.NameToLayer("Ignore");
            item.enabled = true;
        }

        foreach (var item in ragDollRb)
        {
            item.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * magnitude, ForceMode.Impulse);
            item.isKinematic = false;
        }

        _mainCollider.enabled = false;
        _enemy.GetComponent<Rigidbody>().isKinematic = true;


        ApplyForce(dir * magnitude);

    }

    public void ApplyForce(Vector3 vec)
    {
        var rb = _hips.GetComponent<Rigidbody>();
        vec.y = 2;
        rb.AddForce(vec, ForceMode.VelocityChange);
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
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Vector3 direction = collision.contacts[0].point - _enemy.transform.position;
            direction = -direction.normalized;
            _enemy.GetComponent<Rigidbody>().AddForce(direction * magnitude, ForceMode.Impulse);
        }
    }

}
