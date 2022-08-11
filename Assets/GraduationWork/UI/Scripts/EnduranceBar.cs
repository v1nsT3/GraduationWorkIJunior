using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnduranceBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ChangeEndurance += OnChangeValue;
    }

    private void OnDisable()
    {
        _player.ChangeEndurance -= OnChangeValue;
    }
}
