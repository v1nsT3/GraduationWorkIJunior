using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveState : State
{
    [SerializeField] private float _speed;

    private Animator _animator;

    private void OnEnable()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();

        _animator.SetBool(AnimatorController.Params.IsMove, true);
    }

    private void OnDisable()
    {
        _animator.SetBool(AnimatorController.Params.IsMove, false);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Target.transform.position - transform.position, Vector3.up);
    }
}
