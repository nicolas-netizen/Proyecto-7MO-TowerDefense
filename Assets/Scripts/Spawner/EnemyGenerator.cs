using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] public EnemySpawner _enemySpawner;
    void Start(){
        InvokeRepeating("GenerateEnemy", 0f, 2f);
    }

    void GenerateEnemy(){
        _enemySpawner.SpawnEnemy();
        
    }
}
