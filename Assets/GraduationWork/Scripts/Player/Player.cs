using GraduationWork;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerWeapon))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _maxEndurance;
    [SerializeField] private float _increaseEndurancePerSec;
    [SerializeField] private float _increaseHealthPerSec;

    private PlayerWeapon _playerWeapon;
    private float _currentHealth;
    private Animator _animator;
    private float _currentEndurance;
    private int _coins;
    private Coroutine _dieCoroutine;

    public int Coins => _coins;
    public float CurrentHealth => _currentHealth;

    public event UnityAction<float, float> ChangeHealth;
    public event UnityAction<float, float> ChangeEndurance;
    public event UnityAction<int> CoinsChanged;
    public event UnityAction Died;

    private void OnEnable()
    {
        _playerWeapon.EnduranceSpented += OnDecreaseEndurance;
        _playerWeapon.WeaponBuyed += OnReduceCoins;
    }

    private void OnDisable()
    {
        _playerWeapon.EnduranceSpented -= OnDecreaseEndurance;
        _playerWeapon.WeaponBuyed -= OnReduceCoins;
    }

    private void Awake()
    {
        _playerWeapon = GetComponent<PlayerWeapon>();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentHealth = _maxHealth;
        _currentEndurance = _maxEndurance;
    }

    private void Update()
    {
        if (_currentHealth <= 0)
            return;

        if (_currentEndurance < _maxEndurance)
        {
            _currentEndurance = Mathf.MoveTowards(_currentEndurance, _maxEndurance, Time.deltaTime * _increaseEndurancePerSec);
            ChangeEndurance?.Invoke(_currentEndurance, _maxEndurance);
        }

        if (_currentHealth < _maxHealth)
        {
            _currentHealth = Mathf.MoveTowards(_currentHealth, _maxEndurance, Time.deltaTime * _increaseHealthPerSec);
            ChangeHealth?.Invoke(_currentHealth, _maxHealth);
        }
    }

    private void OnDecreaseEndurance(float value)
    {
        _currentEndurance -= value;
        ChangeEndurance?.Invoke(_currentEndurance, _maxEndurance);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();

        ChangeHealth?.Invoke(_currentHealth, _maxHealth);
    }

    public void AddCoins(int coins)
    {
        _coins += coins;
        CoinsChanged?.Invoke(_coins);
    }

    private void Die()
    {
        if (_dieCoroutine == null)
        {
            _animator.SetTrigger(AnimatorController.Params.DiedTrigger);
            _animator.SetBool(AnimatorController.Params.IsDied, true);
            _dieCoroutine = StartCoroutine(DiedDelay());
        }
    }

    private IEnumerator DiedDelay()
    {
        yield return new WaitForSeconds(5);
        Died?.Invoke();
        _dieCoroutine = null;
    }

    public bool TryGetEndurance(float value)
    {
        if (value <= _currentEndurance)
            return true;

        return false;
    }

    private void OnReduceCoins(int coins)
    {
        _coins -= coins;
        CoinsChanged?.Invoke(_coins);
    }

    public void Restart()
    {
        _animator.SetBool(AnimatorController.Params.IsDied, false);
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _coins = 0;
        _currentEndurance = _maxEndurance;
        _currentHealth = _maxHealth;
        ChangeHealth?.Invoke(_currentHealth, _maxHealth);
        ChangeEndurance?.Invoke(_currentEndurance, _maxEndurance);
        _playerWeapon.ResetWeapon();
    }
}
