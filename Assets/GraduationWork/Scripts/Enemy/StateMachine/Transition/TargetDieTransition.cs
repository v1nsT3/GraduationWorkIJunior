using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TargetDieTransition : Transition
{
    private void OnEnable()
    {
        Target.ChangeHealth += OnTargetHealthChanged;
    }

    private void OnDisable()
    {
        Target.ChangeHealth -= OnTargetHealthChanged;
    }

    private void OnTargetHealthChanged(float value, float maxValue)
    {
        if(value <= 0)
            NeedTransit = true;
    }
}
