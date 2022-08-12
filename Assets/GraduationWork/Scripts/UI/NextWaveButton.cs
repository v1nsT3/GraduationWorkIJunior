using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _enemySpawner.AllEnemyDied += OnAllEnemySpawned;
        _button.onClick.AddListener(OnClickButton);
    }

    private void OnDisable()
    {
        _enemySpawner.AllEnemyDied -= OnAllEnemySpawned;
        _button.onClick.RemoveListener(OnClickButton);
    }

    private void OnAllEnemySpawned()
    {
        _button.gameObject.SetActive(true);
    }

    private void OnClickButton()
    {
        _enemySpawner.NextWave();
        _button.gameObject.SetActive(false);
    }
}
