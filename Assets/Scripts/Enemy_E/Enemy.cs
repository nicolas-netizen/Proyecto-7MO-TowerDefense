using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Enemy_Movent _enemyMovent;
    public Enemy_Movent EnemyMovent { get => _enemyMovent; set => _enemyMovent = value; }

    // Start is called before the first frame update
    void Start()
    {
        _enemyMovent.ManualUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
