//using UnityEngine;

//public class EmbateDeJusticia : MonoBehaviour
//{
//    public float cargaSpeed = 10f; // Velocidad de carga
//    public float damageMultiplier = 2f; // Multiplicador de daño durante la carga
//    public float stunDuration = 2f; // Duración del aturdimiento
//    public float markDuration = 5f; // Duración de la marca de justicia
//    public int markDefenseReduction = 20; // Reducción de defensa por la marca de justicia

//    public GameObject target; // Referencia al enemigo objetivo

//    private bool isCharging = false; // Indica si el caballero está cargando
//    private bool isStunned = false; // Indica si el objetivo está aturdido

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
//            // Calcular el daño aumentado durante la carga
//            int damage = CalculateDamage();

//            // Aplicar el daño al objetivo
//            target.GetComponent<Enemy>().TakeDamage(damage);

//            // Aplicar el aturdimiento al objetivo
//            target.GetComponent<Enemy>().Stun(stunDuration);

//            // Aplicar la marca de justicia al objetivo
//            target.GetComponent<Enemy>().ApplyMark(markDuration, markDefenseReduction);
//        }
//    }

//    private int CalculateDamage()
//    {
//        // Calcular el daño aumentado durante la carga
//        int baseDamage = 50; // Daño base sin carga
//        int increasedDamage = Mathf.RoundToInt(baseDamage * damageMultiplier);

//        return increasedDamage;
//    }
//}
