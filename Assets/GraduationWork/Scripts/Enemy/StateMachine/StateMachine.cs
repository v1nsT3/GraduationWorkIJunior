using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    [SerializeField] private State _defaultState;
    [SerializeField] private Player _target;

    [SerializeField] private State _currentState;

    public State CurrentState => _currentState;

    private void OnEnable()
    {
        if (_target == null)
            _target = GetPlayer();
    }

    private void OnDisable()
    {
        foreach (var state in GetComponents<State>())
            state.enabled = false;

        foreach (var transition in GetComponents<Transition>())
        {
            transition.Restart();
            transition.enabled = false;
        }

        _currentState = null;
    }

    private void Start()
    {
        SetDefaultState();
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    public void Restart()
    {
        SetDefaultState();
    }

    public void Transit(State state)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = state;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void SetDefaultState()
    {
        _currentState = _defaultState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    protected virtual void EnterState(Player player)
    {
        if (_currentState != null)
            _currentState.Enter(player);
    }

    protected abstract Player GetPlayer();
}
