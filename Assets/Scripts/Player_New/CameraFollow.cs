using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0, 2, -10);
    [SerializeField] private float smoothTime = 0.25f;
    private Vector3 currentVelocity;

    private bool isShaking = false;

    public void Shake()
    {
        if (!isShaking)
        {
            StartCoroutine(ShakeCoroutine());
        }
    }

    private IEnumerator ShakeCoroutine()
    {
        Vector3 initialPosition = transform.position;
        float shakeDuration = 0.1f;
        float shakeMagnitude = 0.1f;

        isShaking = true;

        while (shakeDuration > 0)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;
            transform.position = _target.position + _offset + randomOffset;
            shakeDuration -= Time.deltaTime;

            yield return null;
        }

        isShaking = false;
        transform.position = initialPosition;
    }

    private void LateUpdate()
    {
        if (!isShaking)
        {
            transform.position = Vector3.SmoothDamp(
                transform.position,
                _target.position + _offset,
                ref currentVelocity,
                smoothTime
            );
        }
    }
}
