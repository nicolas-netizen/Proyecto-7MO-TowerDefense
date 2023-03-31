using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    private Player player;
    private GameObject reference;
    private Vector3 distance;

    public void DistanceStrat() {
        player = FindObjectOfType<Player>();
        distance = transform.position - player.transform.position;   
    }
    public void DistanceLateUpdate()
    {
        distance = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2, Vector3.up) * distance;
        
        transform.position = player.transform.position + distance;
        transform.LookAt(player.transform.position);

        Vector3 copiaRotacion = new Vector3(0, transform.eulerAngles.y, 0);
        reference.transform.eulerAngles = copiaRotacion;
    }
}