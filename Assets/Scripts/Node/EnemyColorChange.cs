using UnityEngine;

public class EnemyColorChange : MonoBehaviour
{
    public Color enemyApproachColor;
    private Color originalColor;
    private Light lightComponent;

    private void Start()
    {
        lightComponent = GetComponent<Light>();
        originalColor = lightComponent.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            lightComponent.color = enemyApproachColor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            lightComponent.color = originalColor;
        }
    }
}