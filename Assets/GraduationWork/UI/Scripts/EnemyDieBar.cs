using UnityEngine;

public class EnemyDieBar : Bar
{
    [SerializeField] private EnemySpawner _enemySpawner;

    private void OnEnable()
    {
        _enemySpawner.EnemyDied += OnChangeValue;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemyDied -= OnChangeValue;
    }
}
