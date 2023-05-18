using System.Collections;
using UnityEngine;

[System.Serializable]
public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _shakeDuration = 0.5f; 
    [SerializeField] private float _shakeMagnitude = 0.1f; 

    private Transform cameraTransform;
    private Vector3 originalPosition;

    void Awake()
    {
        cameraTransform = GetComponent<Transform>();
    }

    public void Shake()
    {
        originalPosition = cameraTransform.localPosition;
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * _shakeMagnitude;
            float y = Random.Range(-1f, 1f) * _shakeMagnitude;

            cameraTransform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        cameraTransform.localPosition = originalPosition;
    }
}
