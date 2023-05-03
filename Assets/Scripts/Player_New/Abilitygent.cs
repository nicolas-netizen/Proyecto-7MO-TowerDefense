using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Abilitygent : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f; 
    public float damage = 10f;
    public float chargeTime = 1f; 

    public Animator animator; 
    public ParticleSystem particles; 

    private bool _charging = false; 
    private Vector3 _chargeDirection; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !_charging) 
        {
            animator.SetTrigger("Charge");

            StartCoroutine(Charge());
        }
    }

    private IEnumerator Charge()
    {
       
        float currentSpeed = speed;

       
        yield return new WaitForSeconds(chargeTime);

        particles.Play(); 

       
        while (_charging)
        {
           
            transform.position += _chargeDirection * currentSpeed * Time.deltaTime;

           
            currentSpeed -= Time.deltaTime * speed * 0.5f;

            yield return null;
        }

        particles.Stop(); 
    }

  //  private void OnTriggerEnter(Collider other)
    //{
       // if (charging)
       // {
           // Enemy enemy = other.GetComponent<Enemy>();

           // if (enemy != null)
            //{
              //  enemy.TakeDamage(damage); // Infligir daño al enemigo
            //}
       // }
   // }

    private void OnTriggerExit(Collider other)
    {
        if (_charging)
        {
           
            _charging = false;
        }
    }

   
    private void StartCharge()
    {
        _charging = true;
        _chargeDirection = transform.forward; 
    }
}


