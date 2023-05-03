using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow : MonoBehaviour
{
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    public void ManualUpdate()
    {
        Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
    }
}
