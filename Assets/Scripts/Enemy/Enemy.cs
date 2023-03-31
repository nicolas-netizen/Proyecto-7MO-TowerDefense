using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Enemy_Damage damage;
    [SerializeField] private Enemy_Health _healthController;
    // Start is called before the first frame update

    private void Awake()
    {
        _healthController.SetEnemy(this);  
    }

    void Start()
    {
        _healthController.ManualStart();
    }
}
