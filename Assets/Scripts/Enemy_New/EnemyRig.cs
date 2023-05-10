//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[System.Serializable]
// public class EnemyRig 
//{
//    [SerializeField] public float explosionForce = 10f;
//    [SerializeField] private Rigidbody rb;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Explosion"))
//        {
//            rb.AddForce(Vector3.up * explosionForce, ForceMode.Impulse);
//        }
//    }
//}
