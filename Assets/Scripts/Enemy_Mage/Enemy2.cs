using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
   [SerializeField] public float _attackRange = 3f;
   [SerializeField] public float _fleeRange = 5f;
   [SerializeField] public float _moveSpeed = 3f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= _attackRange)
        {
            // Implementa el ataque al jugador (stun, reducción de vida, etc.)
        }
        else if (distanceToPlayer <= _fleeRange)
        {
            // Huye del jugador
            Vector3 fleeDirection = transform.position - player.position;
            transform.Translate(fleeDirection.normalized * _moveSpeed * Time.deltaTime);
        }
    }
}
