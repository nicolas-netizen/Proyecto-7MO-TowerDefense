using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy_Damage : MonoBehaviour
{
    [SerializeField] private int _damage = 20;
    [SerializeField] private bool _isAttacking;

    public bool IsAttacking { get => _isAttacking; set => _isAttacking = value; }
    public int Damage { get => _damage; set => _damage = value; }

    public void Attack(Collider other)
    {
        Player playerHealth = other.gameObject.GetComponent<Player>();
        if (playerHealth != null && _isAttacking)
        {
            playerHealth.HealthController.UpdateHealth(-_damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            Attack(other);
    }
}
