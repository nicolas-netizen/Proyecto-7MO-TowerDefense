using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Enemy_Follow _enemyFollow;
    [SerializeField] private Enemy_Movent _enemyMovent;

    public Enemy_Follow EnemyFollow { get => _enemyFollow; set => _enemyFollow = value; }
    public Enemy_Movent EnemyMovent { get => _enemyMovent; set => _enemyMovent = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _enemyFollow.ManualUpdate();
        _enemyMovent.ManualUpdate();
    }
}
