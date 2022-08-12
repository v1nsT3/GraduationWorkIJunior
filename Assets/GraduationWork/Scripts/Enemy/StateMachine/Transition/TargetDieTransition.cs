using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TargetDieTransition : Transition
{
    private void Update()
    {
        if (Target.IsDead)
        {
            NeedTransit = true;
        }
    }
}
