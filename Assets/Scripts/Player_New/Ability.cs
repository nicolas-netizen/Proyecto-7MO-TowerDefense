//using UnityEngine;
//[System.Serializable]
//public class Ability 
//{
//    [SerializeField] public Animator animator; // Referencia al componente Animator del personaje
//    [SerializeField] public string abilityTrigger = "AbilityTrigger"; // Nombre del par�metro de activaci�n de la animaci�n de la habilidad
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
//        animator.SetTrigger(abilityTrigger); // Activa la reproducci�n de la animaci�n de la habilidad
//    }
//    private Player _player;
//    public void SetPlayer(Player player)
//    {
//        _player = player;
//    }
//}

