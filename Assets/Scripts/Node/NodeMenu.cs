using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMenu : MonoBehaviour
{
    [SerializeField] private Node _nextNode;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().NextNodeMenu(_nextNode);
        }
    }
}
