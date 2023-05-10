using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movent : MonoBehaviour
{
    public Transform Player; // Referencia al Transform del jugador
    public float speed = 5f; // Velocidad del enemigo

    public void ManualUpdate()
    {
        // Calcula la dirección hacia el jugador
        Vector3 direction = Player.position - transform.position;

        // Normaliza la dirección para obtener una velocidad constante
        direction.Normalize();

        // Mueve el enemigo hacia el jugador a la velocidad especificada
        transform.position += direction * speed * Time.deltaTime;
    }
}

