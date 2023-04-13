using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0, 2, -10);
    [SerializeField] private float smoothTime = 0.25f;
    private Vector3 currentVelocity;
    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            _target.position + _offset,
            ref currentVelocity,
            smoothTime
            );
    }
}
