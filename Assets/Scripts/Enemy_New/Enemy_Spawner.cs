using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    var Enemy:Transform;
private var Timer:float;
 
function Awake()
    {
        Timer = Time.time + 15;// THIS (15) IS THE SECONDS (TIME) IN WHICH THE ENEMY IS GOING TO SPAWN FOR THE FIRST TIME 
    }

    function Update()
    {
        if (Timer < Time.time)
        { //This checks wether real time has caught up to the timer
            Instantiate(Enemy, transform.position, transform.rotation); //This spawns the emeny
            Timer = Time.time + 15; // THIS (15) IS THE SECONDS (TIME) IN WHICH THE ENEMY IS GOING TO SPAWN FOR THE SECOND TIME 
        }
    }
}
