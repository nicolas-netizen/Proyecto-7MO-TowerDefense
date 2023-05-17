//using UnityEngine;
//[System.Serializable]
//public class Ability 
//{
//    [SerializeField] public Animator animator; // Referencia al componente Animator del personaje
//    [SerializeField] public string abilityTrigger = "AbilityTrigger"; // Nombre del parámetro de activación de la animación de la habilidad
//    [SerializeField] public KeyCode activationKey = KeyCode.A; // Tecla para activar la habilidad

//    private void Update()
//    {
//        if (Input.GetKeyDown(activationKey))
//        {
//            ActivateAbility();
//        }
//    }

//    public void ActivateAbility()
//    {
//        animator.SetTrigger(abilityTrigger); // Activa la reproducción de la animación de la habilidad
//    }
//    private Player _player;
//    public void SetPlayer(Player player)
//    {
//        _player = player;
//    }
//}

