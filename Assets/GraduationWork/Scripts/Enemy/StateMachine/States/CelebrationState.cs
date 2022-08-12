using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private Animator _animator;

    private void OnEnable()
    {
        _animator.SetTrigger(AnimatorController.Params.CelebrationTrigger);
        _animator.SetBool(AnimatorController.Params.IsCelebration, true);
    }

    private void OnDisable()
    {
        _animator.SetBool(AnimatorController.Params.IsCelebration, false);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
