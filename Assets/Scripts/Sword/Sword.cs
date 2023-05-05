using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private ISwordOwner _owner;

    private void Start()
    {
        _owner = transform.root.GetComponent<ISwordOwner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var col = other.gameObject?.GetComponent<IDamageable>();

        if (col != null)
        {
            if (col.GetObject() != _owner.GetOwner() && _owner.CheckAttacking())
            {
                col.TakeDamage(_owner.GetDamage());
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var col = other.gameObject?.GetComponent<IDamageable>();
        if (col != null)
        {
            if (col.GetObject() != _owner.GetOwner() && _owner.CheckAttacking())
            {
                col.TakeDamage(_owner.GetDamage());
            }
        }
    }
}
