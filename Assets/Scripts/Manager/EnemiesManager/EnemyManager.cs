using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private Node[] _startNodes;
    [SerializeField] private List<NodeEscape> _escapeNodes;


    public static EnemyManager Instance;

    public Player Player { get => _player; set => _player = value; }
    public Transform EndPoint { get => _endPoint; set => _endPoint = value; }
    public List<NodeEscape> EscapeNodes { get => _escapeNodes; set => _escapeNodes = value; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public Node GetStartNode()
    {
        System.Random r = new System.Random();
        return _startNodes[r.Next(0, _startNodes.Length)];
    }
}
