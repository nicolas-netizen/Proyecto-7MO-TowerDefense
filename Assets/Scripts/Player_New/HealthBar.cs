using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image healthBarImage; 

    private float initialFillAmount;

    private void Start()
    {
        // Almacenar el valor fill amount inicial
        initialFillAmount = healthBarImage.fillAmount;
    }

    private void Update()
    {
        if (playerHealth != null)
        {
            float currentFillAmount = (float)playerHealth.currentHealth / playerHealth.maxHealth;

            // Actualizar el fill amount de la imagen
            healthBarImage.fillAmount = Mathf.Lerp(healthBarImage.fillAmount, currentFillAmount, Time.deltaTime * 5f);
        }
    }
}
