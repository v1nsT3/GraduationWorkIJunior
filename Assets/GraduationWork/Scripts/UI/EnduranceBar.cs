using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnduranceBar : Bar
{
    [SerializeField] private Endurance _endurance;

    private void OnEnable()
    {
        _endurance.ChangedValue += OnChangeValue;
    }

    private void OnDisable()
    {
        _endurance.ChangedValue -= OnChangeValue;
    }
}
