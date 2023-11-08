using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float DestroyText = 2f;
    public Vector3 Offset = new Vector3(0, 2, 0);
    public Vector3 RandomOffset = new Vector3(0.5f, 0, 0); 

    void Start()
    {
        Destroy(gameObject, DestroyText);
        transform.localPosition += Offset;
        transform.localPosition += new Vector3(
            Random.Range(-RandomOffset.x, RandomOffset.x),
            Random.Range(-RandomOffset.y, RandomOffset.y),
            Random.Range(-RandomOffset.z, RandomOffset.z)
        );
    }
}
