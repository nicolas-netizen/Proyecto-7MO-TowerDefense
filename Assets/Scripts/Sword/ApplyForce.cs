using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ApplyForce : MonoBehaviour
{
    [SerializeField] private float _magnitude = 1000f;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Vector3 direction = collision.contacts[0].point - transform.position;
            direction = -direction.normalized;
            GetComponent<Rigidbody>().AddForce(direction * _magnitude, ForceMode.Impulse);

            // Añadir fuerza aleatoria adicional
            GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)), ForceMode.Impulse);
        }
    }

}

