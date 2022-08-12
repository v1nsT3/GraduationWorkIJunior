using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : StateMachine
{
    protected override Player GetPlayer()
    {
        return GetComponent<Enemy>().Target;
    }
}
