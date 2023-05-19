using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Node _nextNode;
    [SerializeField] private bool _endNode;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && !_endNode)
        {
            other.GetComponent<IWaveable>().NextNode(_nextNode);
        }
    }
}
