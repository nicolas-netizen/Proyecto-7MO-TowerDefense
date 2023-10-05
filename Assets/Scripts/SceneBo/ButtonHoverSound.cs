using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioSource hoverSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null)
        {
            hoverSound.Play();
        }
    }
}

