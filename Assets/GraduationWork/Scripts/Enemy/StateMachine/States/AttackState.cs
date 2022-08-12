using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private float _damage;

    private Animator _animator;
    private float _lastAttackTime;

    private void OnEnable()
    {
        if(_animator == null)
            _animator = GetComponent<Animator>();

        _animator.SetBool(AnimatorController.Params.IsAttack, true);
    }

    private void OnDisable()
    {
        _animator.SetBool(AnimatorController.Params.IsAttack, false);
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(Target.transform.position - transform.position, Vector3.up);

        if(_lastAttackTime >= _delay)
        {
            _lastAttackTime = 0;
            Attack();
        }

        _lastAttackTime += Time.deltaTime;
    }

    private void Attack()
    {
        _animator.SetTrigger(AnimatorController.Params.AttackTrigger);
        Target.TakeDamage(_damage);
    }
}
