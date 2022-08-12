using UnityEngine;
using DG.Tweening;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class DiedState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private Coin _coin;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private Rigidbody _rigidbody;

    private Animator _animator;
    private Tween _tween;

    private void OnEnable()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();

        _animator.SetBool(AnimatorController.Params.IsDied, true);

        _capsuleCollider.isTrigger = true;
        _rigidbody.isKinematic = true;

        StartCoroutine(Deactivate());
    }

    private void OnDisable()
    {
        _animator.SetBool(AnimatorController.Params.IsDied, false);
        _capsuleCollider.isTrigger = false;
        _rigidbody.isKinematic = false;
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(_delay);

        _tween = transform.DOMoveY(-_delay, _delay);

        yield return new WaitForSeconds(_delay);

        transform.gameObject.SetActive(false);
    }
}
