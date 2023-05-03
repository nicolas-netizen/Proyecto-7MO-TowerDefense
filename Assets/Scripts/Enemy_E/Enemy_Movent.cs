using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movent : MonoBehaviour
{
    public int routine;
    public float nchronometer;
    public Animation ani;
    public Quaternion angle;
    public float degree;

    public void SetEnemy() 
    {
        ani = GetComponent<Animation>();
    }

    public void ManualUpdate()
    {
        nchronometer += 1 * Time.deltaTime;
        if(nchronometer>4)
        {
            routine = Random.Range(100,200);
            nchronometer = 0;
        }
        switch(routine)
        {
            case 0:
                ani.SetBool("walk",false);
                break;
            case 1:
                degree = Random.Range(0, 360);
                angle = Quaternion.Euler(0, degree, 0);
                routine++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                ani.SetBool("walk", true);
                break;
        }

    }

}
