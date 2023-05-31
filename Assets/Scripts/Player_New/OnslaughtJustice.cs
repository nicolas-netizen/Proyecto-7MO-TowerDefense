//using UnityEngine;

//public class EmbateDeJusticia : MonoBehaviour
//{
//    public float cargaSpeed = 10f; // Velocidad de carga
//    public float damageMultiplier = 2f; // Multiplicador de da�o durante la carga
//    public float stunDuration = 2f; // Duraci�n del aturdimiento
//    public float markDuration = 5f; // Duraci�n de la marca de justicia
//    public int markDefenseReduction = 20; // Reducci�n de defensa por la marca de justicia

//    public GameObject target; // Referencia al enemigo objetivo

//    private bool isCharging = false; // Indica si el caballero est� cargando
//    private bool isStunned = false; // Indica si el objetivo est� aturdido

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            if (!isCharging)
//            {
//                // Iniciar la carga
//                isCharging = true;
//                StartCoroutine(Charge());
//            }
//        }
//    }

//    private IEnumerator Charge()
//    {
//        // Realizar la carga durante un tiempo determinado
//        float chargeTime = 2f;
//        float timer = 0f;

//        while (timer < chargeTime)
//        {
//            timer += Time.deltaTime;

//            // Mover al caballero hacia adelante durante la carga
//            transform.Translate(Vector3.forward * cargaSpeed * Time.deltaTime);

//            yield return null;
//        }

//        // Finalizar la carga
//        isCharging = false;

//        // Aplicar el ataque al enemigo objetivo
//        if (target != null)
//        {
//            // Calcular el da�o aumentado durante la carga
//            int damage = CalculateDamage();

//            // Aplicar el da�o al objetivo
//            target.GetComponent<Enemy>().TakeDamage(damage);

//            // Aplicar el aturdimiento al objetivo
//            target.GetComponent<Enemy>().Stun(stunDuration);

//            // Aplicar la marca de justicia al objetivo
//            target.GetComponent<Enemy>().ApplyMark(markDuration, markDefenseReduction);
//        }
//    }

//    private int CalculateDamage()
//    {
//        // Calcular el da�o aumentado durante la carga
//        int baseDamage = 50; // Da�o base sin carga
//        int increasedDamage = Mathf.RoundToInt(baseDamage * damageMultiplier);

//        return increasedDamage;
//    }
//}
