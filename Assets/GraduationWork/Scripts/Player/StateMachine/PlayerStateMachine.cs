using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerStateMachine : StateMachine
{
    protected override Player GetPlayer()
    {
        return GetComponent<Player>();
    }
}
