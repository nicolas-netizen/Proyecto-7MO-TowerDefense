using UnityEngine;


public class ProjectileMage : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed = 10f;

    private Transform _target;
    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Start()
    {
        transform.LookAt(_target);
    }

    private void Update()
    {
        if (_target != null)
        {
            transform.position += transform.forward * _projectileSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
