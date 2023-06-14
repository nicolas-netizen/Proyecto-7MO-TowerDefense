//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Ability2 : MonoBehaviour
//{
//    [SerializeField] private Player _player;
//    [SerializeField] private float damage;
//    [SerializeField] private float range;
//    [SerializeField] private float cooldown;

//    [SerializeField] private GameObject sword;

//    [SerializeField] private bool isCooldown = false;
//    [SerializeField] private Animator animator;

//    private void Update()
//    {
//        if (!isCooldown && Input.GetKeyDown(KeyCode.F))
//        {
//            ActivateAbility();
//        }
//    }

//    private void ActivateAbility()
//    {
//        if (sword != null)
//        {
//            sword.SetActive(true);

//            CameraShake cameraShake = Camera.main.GetComponent<CameraShake>();
//            if (cameraShake != null)
//            {
//                cameraShake.Shake();
//            }

//            Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
//            foreach (Collider hitCollider in hitColliders)
//            {
//                if (hitCollider.CompareTag("Enemy"))
//                {
//                    Enemy enemy = hitCollider.GetComponent<Enemy>();
//                    if (enemy != null)
//                    {
//                        Vector3 dir = hitCollider.transform.position - transform.position;
//                        enemy.TakeDamage(damage, dir);
//                    }
//                }
//            }

//            StartCoroutine(CooldownRoutine());
//        }
//    }

//    private IEnumerator CooldownRoutine()
//    {
//        isCooldown = true;
//        yield return new WaitForSeconds(cooldown);
//        isCooldown = false;
//    }
//}
