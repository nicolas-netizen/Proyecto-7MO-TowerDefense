using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ISwordOwner
{
    [SerializeField] private PlayerMovement _movementController;
    [SerializeField] private PlayerInput _inputController;
    [SerializeField] private PlayerState _stateController;
    [SerializeField] private PlayerRotation _rotationController;
    [SerializeField] private PlayerAnimation _animationController;
    [SerializeField] private PlayerCombo _playerCombo;
    [SerializeField] private PlayerCombat _playerCombat;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerVFX _playerVFX;
    [SerializeField] private KnightAbility _knightAbility;
    [SerializeField] private ChargeAbility _chargeAbility;

    [Header("SOUND")]
    [SerializeField] private AudioSource _audioSlash;
    [SerializeField] private AudioSource ToonEXplot;
    public PlayerMovement MovementController { get => _movementController; set => _movementController = value; }
    public PlayerInput InputController { get => _inputController; set => _inputController = value; }
    public PlayerState StateController { get => _stateController; set => _stateController = value; }
    public PlayerRotation RotationController { get => _rotationController; set => _rotationController = value; }
    public PlayerCombo PlayerCombo { get => _playerCombo; set => _playerCombo = value; }
    public PlayerCombat PlayerCombat { get => _playerCombat; set => _playerCombat = value; }
    public PlayerHealth PlayerHealth { get => _playerHealth; set => _playerHealth = value; }
    public PlayerAnimation AnimationController { get => _animationController; set => _animationController = value; }
    public KnightAbility KnightAbility { get => _knightAbility; set => _knightAbility = value; }
    public PlayerVFX PlayerVFX { get => _playerVFX; set => _playerVFX = value; }
    public ChargeAbility ChargeAbility { get => _chargeAbility; set => _chargeAbility = value; }
    public AudioSource AudioSlash { get => _audioSlash; }
    public AudioSource ToonEXplot1 { get => ToonEXplot; }

    void Start()
    {
        _movementController.SetPlayer(this);
        _inputController.SetPlayer(this);
        _stateController.SetPlayer(this);
        _rotationController.SetPlayer(this);
        _animationController.SetPlayer(this);
        _playerCombo.SetPlayer(this);
        _playerHealth.SetPlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
        _movementController.ManualUpdate();
        _inputController.ManualUpdate();
        _animationController.ManualUpdate();
        _playerCombo.ManualUpdate();
    }
    public float GetDamage()
    {
        return _playerCombat.BasicDamage;
    }

    public GameObject GetOwner()
    {
        return gameObject;
    }

    public bool CheckAttacking()
    {
        return _playerCombat.IsAttacking;
    }

    public AttackDir CheckAttackDir()
    {
        return _playerCombat.AttackDirection;
    }
    public void Stun(float duration)
    {
        StartCoroutine(StunCoroutine(duration));
    }

    private IEnumerator StunCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
    }

}
