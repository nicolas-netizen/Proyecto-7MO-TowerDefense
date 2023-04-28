using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {
    [Serailzefield]
    private GameObject prefacEnemy;
    private GameObject _enemy;

    void Uodate
        {
            if(_enemy==null)
            {
                _enemy = instantiate(prefacEnemy) as GameObject;
                _enemy.transform.position = new vector3(0,1,4);
                float angulo = Randos.Rage(0, 360);
                _enemy.Trensform.Rotate(0,angulo,o)
            }
        }

}
