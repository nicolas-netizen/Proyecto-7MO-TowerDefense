using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow : MonoBehaviour
{
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    bool estarAlerta;
    public Transform player;
    public void ManualUpdate()
    {
        estarAlerta=Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if(estarAlerta == true)
        {
            transform.LookAt(new Vector3(transform.position.x, player.position.y, player.position.z));
        }
    }
    public void EnemyGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
}
