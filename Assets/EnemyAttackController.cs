using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : StateMachineBehaviour
{
    [SerializeField] private int _maxRange;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger(AnimatorController.Params.AttackId, Random.Range(0, _maxRange));
    }
}
