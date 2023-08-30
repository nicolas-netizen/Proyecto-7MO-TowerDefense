using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] private List<NodeEscape> _nodes = new List<NodeEscape>();

    public List<NodeEscape> Nodes { get => _nodes; set => _nodes = value; }

    private void Start()
    {
        EnemyManager.Instance.EscapeNodes = _nodes;
    }
}
