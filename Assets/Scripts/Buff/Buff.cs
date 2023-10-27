using UnityEngine;
using System.Collections;

public class Buff : MonoBehaviour
{
    public enum BuffType
    {
        Speed,
        Scale,
        AttackSpeed,
    }

    [Header("General")]
    [SerializeField] private GameObject _player;

    [Header("Buff Settings")]
    [SerializeField] private BuffType _currentBuff;
    [SerializeField] private int _BuffCost = 10;
    [SerializeField] private float _activationRange = 5f;
    [SerializeField] private KeyCode _activationKey = KeyCode.Q;
    [SerializeField] private float _BuffValue;
    [SerializeField] private GameObject _buffPlayer;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private GameObject _LuzBufo;
    [SerializeField] private GameObject _startParticle;
    [SerializeField] private GameObject _endParticle;

    private bool isBuffActive = false;
    private bool isOnCooldown = false;
    private float cooldownDuration = 30.0f;
    private float cooldownTimer = 0.0f;

    private Vector3 originalScale; 

    public TowerUI ui;
    [SerializeField] private AudioSource BuYtower;

    private void Start()
    {
        _LuzBufo.SetActive(false);
        _startParticle.SetActive(false);
        originalScale = _buffPlayer.transform.localScale;
    }

    private void Update()
    {
        if (!isBuffActive && !isOnCooldown)
        {
            var near = IsPlayerNearTrap();
            var afford = CanAffordBuff();

            if (Input.GetKeyDown(KeyCode.Q) && near && afford)
            {
                TryToActivateBuff();
            }
        }
        else if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                isOnCooldown = false;

                _buffPlayer.transform.localScale = originalScale;
            }
        }
    }

    public bool CanAffordBuff()
    {
        return CoinManager.Instance.HasEnoughCoins(_BuffCost);
    }

    private void TryToActivateBuff()
    {
        if (CanAffordBuff())
        {
            BuYtower.Play();
            CoinManager.Instance.SubtractCoins(_BuffCost);
            isBuffActive = true;
            ui.HidePriceSprites();
            CoinManager.Instance.UpdateUI();
            ApplyBuff(_currentBuff);
            StartCoroutine(StartCooldown());
        }
    }

    private bool IsPlayerNearTrap()
    {
        float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
        return distanceToPlayer <= _activationRange;
    }

    private void ApplyBuff(BuffType buff)
    {
        switch (buff)
        {
            case BuffType.Speed:
                ApplySpeedBuff();
                break;
            case BuffType.Scale:
                ApplyScaleBuff();
                break;
            case BuffType.AttackSpeed:
                ApplyAttackSpeedBuff();
                break;
        }
    }

    private void ApplySpeedBuff()
    {
        var playerMovement = _player.gameObject.GetComponent<Player>();
        if (playerMovement != null)
        {
            playerMovement.MovementController.IncreaseSpeed(_BuffValue);
            _LuzBufo.SetActive(true);
            _startParticle.SetActive(true);
        }
    }

    private void ApplyScaleBuff()
    {
        _buffPlayer.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
        _LuzBufo.SetActive(true);
        _startParticle.SetActive(true);
    }

    private void ApplyAttackSpeedBuff()
    {
        if (_playerAnimator != null)
        {
            _playerAnimator.SetFloat("AttackSpeed", _BuffValue);
        }
    }

    private IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        _buffPlayer.transform.localScale = originalScale;
        _LuzBufo.SetActive(false);
        _endParticle.SetActive(false);
        isBuffActive = false;
        isOnCooldown = true;
        cooldownTimer = cooldownDuration;
    }
}
