using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Salud : MonoBehaviour
{
	public int Vida = 100;
	public GameObject DestruirOtro;

	public Slider vidaVisual;

	private void Update()
	{
		vidaVisual.GetComponent<Slider>().value = Vida;
		if (Vida <= 0)
		{
			if (DestruirOtro != null)
			{
				Destroy(DestruirOtro);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}

