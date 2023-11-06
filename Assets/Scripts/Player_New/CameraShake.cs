using System.Collections;
using UnityEngine;

[System.Serializable]
public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _shakeDuration = 0.1f; 
    [SerializeField] private float _shakeMagnitude = 0.3f;
    [SerializeField] private float _shakeMagnitudeAbility = 0.4f;

    private Transform cameraTransform;
    private Vector3 originalPosition; 

    public float ShakeMagnitudeAbility { get => _shakeMagnitudeAbility; set => _shakeMagnitudeAbility = value; }
    public float ShakeMagnitude { get => _shakeMagnitude; set => _shakeMagnitude = value; }

    void Awake()
    {
        cameraTransform = GetComponent<Transform>();
        originalPosition = cameraTransform.localPosition; 
    }

    public void Shake(float magnitude)
    {
        StartCoroutine(ShakeCoroutine(magnitude));
    }

    private IEnumerator ShakeCoroutine(float magnitude)
    {
        float elapsedTime = 0f;

        while (elapsedTime < _shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            cameraTransform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        cameraTransform.localPosition = originalPosition;
    }
}
