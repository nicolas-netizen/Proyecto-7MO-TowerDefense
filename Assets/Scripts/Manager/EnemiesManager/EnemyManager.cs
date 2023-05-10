using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _endPoint;

    public static EnemyManager Instance;

    public Player Player { get => _player; set => _player = value; }
    public Transform EndPoint { get => _endPoint; set => _endPoint = value; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
