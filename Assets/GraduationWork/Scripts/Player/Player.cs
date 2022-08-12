using GraduationWork;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerWeapon))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Endurance _endurance;
    [SerializeField] private PlayerWallet _playerWallet;

    private float _durationDyingPerSec = 5;
    private PlayerWeapon _playerWeapon;
    private Animator _animator;
    private Coroutine _dieCoroutine;

    public bool IsDead => _health.IsDead;

    public event UnityAction Died;

    private void Awake()
    {
        _playerWeapon = GetComponent<PlayerWeapon>();
    }

    private void OnEnable()
    {
        _health.ChangedValue += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.ChangedValue -= OnHealthChanged;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    public void TryBuyWeapon(Weapon weapon)
    {
        _playerWeapon.TryBuyWeapon(weapon, _playerWallet);
    }

    private void OnHealthChanged(float value, float maxValue)
    {
        if (value == 0)
            Die();
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
        yield return new WaitForSeconds(_durationDyingPerSec);
        Died?.Invoke();
        _dieCoroutine = null;
    }

    public void Restart()
    {
        _animator.SetBool(AnimatorController.Params.IsDied, false);
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _endurance.Restart();
        _health.Restart();
        _playerWallet.Restart();
        _playerWeapon.Restart();
    }
}
