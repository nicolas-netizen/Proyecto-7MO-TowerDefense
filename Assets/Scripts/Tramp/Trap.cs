using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject _player;

    [Header("Trap Settings")]
    [SerializeField] private int _trapCost = 10;
    [SerializeField] private int _damage = 30;
    [SerializeField] private float _activationRange = 5f;
    [SerializeField] private KeyCode _activationKey = KeyCode.Q;

    [Header("Trap Animation")]
    [SerializeField] private Animator _trapAnimator;

    private bool isTrapActive = false;
    public TowerUI ui;
    private bool _activeSwitch;
    private bool _canDamage;
    public void StateSwitch(bool state)
    {
        _activeSwitch = state;
        if(state == true)
        {
            _trapAnimator.Play("TrapUp");
        }
    }

    public void StateDamage(bool state)
    {
        _canDamage = state;
    }

    private void Update()
    {
        if (!isTrapActive)
        {
            var near = IsPlayerNearTrap();
            var afford = CanAffordTrap();

            if (Input.GetKeyDown(KeyCode.Q) && near && afford)
            {
                TryToActivateTrap();
            }
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && isTrapActive)
        {

            if (!_activeSwitch)
            {
                StateSwitch(true);
                Enemy enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(_damage);
                }

            }

            if (_canDamage)
            {
                // Aplicar daño al enemigo
                Enemy enemy = other.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(_damage);
                }
            }
        }
    }

    public bool CanAffordTrap()
    {
        return CoinManager.Instance.HasEnoughCoins(10);
    }

    private void TryToActivateTrap()
    {
        if (CanAffordTrap())
        {
            CoinManager.Instance.SubtractCoins(_trapCost);
            isTrapActive = true;
            ui.HidePriceSprites();
            CoinManager.Instance.UpdateUI();
        }
    }

    private bool IsPlayerNearTrap()
    {
        float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
        return distanceToPlayer <= _activationRange;
    }
}
