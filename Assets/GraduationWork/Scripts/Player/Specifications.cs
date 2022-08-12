using UnityEngine;
using UnityEngine.Events;

public abstract class Specifications : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    [SerializeField] private float _increaseValuePerSec;

    private float _currentValue;

    protected float CurrentValue => _currentValue;

    public event UnityAction<float, float> ChangedValue;

    private void Start()
    {
        _currentValue = _maxValue;
    }

    private void Update()
    {
        if (_currentValue <= 0)
            return;

        if (_currentValue < _maxValue)
        {
            _currentValue = Mathf.MoveTowards(_currentValue, _maxValue, Time.deltaTime * _increaseValuePerSec);
            ChangedValue?.Invoke(_currentValue, _maxValue);
        }
    }

    protected void DecreaseValue(float value)
    {
        _currentValue -= value;

        if (_currentValue < 0)
            _currentValue = 0;

        ChangedValue?.Invoke(_currentValue, _maxValue);
    }

    public void Restart()
    {
        _currentValue = _maxValue;
        ChangedValue?.Invoke(_currentValue, _maxValue);
    }
}
