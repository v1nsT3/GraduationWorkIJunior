using UnityEngine;

public class AttackController : StateMachineBehaviour
{
    [SerializeField] private int _range;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(AnimatorController.Params.IsAttack, true);
        animator.SetInteger(AnimatorController.Params.AttackId, Random.Range(0, _range));
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(AnimatorController.Params.IsAttack, false);
    }
}
