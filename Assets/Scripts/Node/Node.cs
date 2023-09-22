using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Node _nextNode;
    [SerializeField] private bool _endNode;
    [SerializeField] private List<Node> _ignoreNextNodes; 
    private void OnTriggerEnter(Collider other)
    {
        var col = other.GetComponent<IWaveable>();

        if (other.CompareTag("Enemy") && col != null && !_endNode)
        {
            col.NextNode(_nextNode, this, _ignoreNextNodes);
        }
    }
}
