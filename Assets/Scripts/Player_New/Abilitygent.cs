using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Abilitygent : MonoBehaviour

    {
    [SerializeField]

        public float speed = 10f;
        public float damage = 10f; 

       // public ParticleSystem chargeParticle; 
        public Animator animator; 

        private bool charging = false; 
        private Vector3 chargeDirection; 

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R) && !charging) 
            {
                charging = true;
                chargeDirection = transform.forward; 

                StartCoroutine(Charge()); 
            }
        }

        private IEnumerator Charge()
        {
            animator.SetBool("IsCharging", true); 
           // chargeParticle.Play(); 

            
            float currentSpeed = speed;

           
            while (charging)
            {
               
                transform.position += chargeDirection * currentSpeed * Time.deltaTime;

               
                currentSpeed -= Time.deltaTime * speed * 0.5f;

                yield return null;
            }

            animator.SetBool("IsCharging", false); 
           // chargeParticle.Stop();
        }

      //  private void OnTriggerEnter(Collider other)
        //{
           // if (charging)
           // {
              //  Enemy enemy = other.GetComponent<Enemy>();

               // if (enemy != null)
              //  {
                   // enemy.TakeDamage(damage); // Infligir daño al enemigo
                //}
            //}
        //}

        private void OnTriggerExit(Collider other)
        {
            if (charging)
            {
                charging = false;
            }
        }
    }





