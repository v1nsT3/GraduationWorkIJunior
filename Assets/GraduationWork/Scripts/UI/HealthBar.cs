using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.ChangedValue += OnChangeValue;
    }

    private void OnDisable()
    {
        _health.ChangedValue -= OnChangeValue;
    }
}
