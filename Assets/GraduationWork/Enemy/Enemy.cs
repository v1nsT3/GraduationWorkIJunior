using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private EnemyStateMachine _enemyStateMachine;

    private float _currentHealth;
    private Animator _animator;
    private Player _target;

    public float MaxHealth => _maxHealth;
    public Player Target => _target;
    public event UnityAction<float> ChangeHealth;
    public event UnityAction<Enemy> Died;

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Died?.Invoke(this);

        ChangeHealth?.Invoke(_currentHealth);
    }

    public void Restart()
    {
        _enemyStateMachine.Restart();
    }
}
