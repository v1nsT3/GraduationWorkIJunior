using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _toState;

    protected Player Target { get; set; }

    public State ToState => _toState;
    public bool NeedTransit { get; protected set; }

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        Restart();
    }

    public void Restart()
    {
        NeedTransit = false;
    }
}
