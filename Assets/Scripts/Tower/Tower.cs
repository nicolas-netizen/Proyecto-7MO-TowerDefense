using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower : MonoBehaviour
{
    public Transform target;
    private Enemy targetEnemy;
    private EnemyM targetEnemyM;
    private  bool isActive = false;
    private bool isLaserActive = false;

    [Header("General")]
    [SerializeField] private GameObject _player;
    public float range = 15f;

    [Header("Use Bullet(default)")]
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public int damageOverTime = 30;
    public float slowAmount = .5f;

    public ParticleSystem hit;
    public ParticleSystem flash;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;

    public int towerPrice = 10;

    [Header("Unity Setup")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;

    public float maxDistanceToActivate = 5f;

    public TowerUI ui;
    [SerializeField] private AudioSource BuYtower;
    [SerializeField] private AudioSource attackSound;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    List<GameObject> _onRange = new List<GameObject>();

    public AudioSource BuYtower1 { get => BuYtower; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTag)
        {
            if(!_onRange.Contains(other.gameObject))
                _onRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == enemyTag)
        {
            if (_onRange.Contains(other.gameObject))
                _onRange.Remove(other.gameObject);
        }
    }

    void UpdateTarget()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        var temp = _onRange.Where(x => x != null).ToList();
        _onRange = temp;

        foreach (GameObject enemy in _onRange)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < range)
            {
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;

            if (nearestEnemy.GetComponent<Enemy>() != null)
            {
                targetEnemy = nearestEnemy.GetComponent<Enemy>();
            }

            if (nearestEnemy.GetComponent<EnemyM>() != null)
            {
                targetEnemyM = nearestEnemy.GetComponent<EnemyM>();
            }
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (!isActive)
        {
            var near = IsPlayerNearTower();
            var afford = CanAffordTower();

            if (Input.GetKeyDown(KeyCode.Q) && near && afford)
            {
                ActivateTower();
            }
            return;
        }

        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                }
            }
            return;
        }
        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    bool CanAffordTower()
    {
        return CoinManager.Instance.HasEnoughCoins(10);
    }

    bool IsPlayerNearTower()
    {
            float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
            return distanceToPlayer <= maxDistanceToActivate;
    }

   public void ActivateTower()
    {
        if (CanAffordTower())
        {
            BuYtower1.Play();
            CoinManager.Instance.SubtractCoins(10);
            ui.HidePriceSprites();
            isActive = true;
            CoinManager.Instance.UpdateUI();
        }
    }



    void Laser()
    {
        if (targetEnemy != null || targetEnemyM != null)
        {
            float currentHealth = 0;

            if (targetEnemy != null)
            {
                currentHealth = targetEnemy.EnemyHealth.CurrentHealth;
                targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
            }

            if (targetEnemyM != null)
            {
                currentHealth = targetEnemyM.EnemyMHealth.CurrentHealth;
                targetEnemyM.EnemyMHealth.UpdateHealth(damageOverTime * Time.deltaTime);
            }

            if (currentHealth > 0)
            {
                if (!lineRenderer.enabled)
                {
                    lineRenderer.enabled = true;
                    impactEffect.Play();
                    hit.Play();
                    flash.Play();
                    isLaserActive = true; // está activo.

                    if (isLaserActive && attackSound != null && !attackSound.isPlaying)
                    {
                        attackSound.Play();
                    }
                }

                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, target.position);

                Vector3 dir = firePoint.position - target.position;

                impactEffect.transform.position = target.position + dir.normalized;
                impactEffect.transform.rotation = Quaternion.LookRotation(dir);
            }
            else
            {
                targetEnemy = null;
                targetEnemyM = null;
                lineRenderer.enabled = false;
                flash.Stop();
                hit.Stop();
            }
        }
        else
        {
            targetEnemy = null;
            targetEnemyM = null;
            lineRenderer.enabled = false;
            flash.Stop();
            hit.Stop();
        }
    }


    void Shoot()
    {
        if (target != null)
        {
            GameObject bulletGO = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Projectile bullet = bulletGO.GetComponent<Projectile>();

            if (bullet != null)
                bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
