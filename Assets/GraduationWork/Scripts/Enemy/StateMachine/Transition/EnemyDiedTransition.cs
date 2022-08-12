using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyDiedTransition : Transition
{
    private Enemy _enemy;

    private void OnEnable()
    {
        if (_enemy == null)
            _enemy = GetComponent<Enemy>();

        _enemy.ChangeHealth += OnDied;
    }

    private void OnDisable()
    {
        _enemy.ChangeHealth -= OnDied;
    }

    private void OnDied(float value)
    {
        if (value <= 0)
            NeedTransit = true;
    }
}
