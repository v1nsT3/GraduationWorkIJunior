using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : CoinsPool
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private EnemySpawner _enemySpawner;

    private List<Enemy> _signedEnemies = new List<Enemy>();
    private float _offsetY = 1;

    private void OnEnable()
    {
        _enemySpawner.EnemySpawned += OnEnemySpawned;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemySpawned -= OnEnemySpawned;
    }

    private void Start()
    {
        FillPool(_prefab);
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        if(_signedEnemies.Contains(enemy) == false)
        {
            enemy.Died += OnEnemyDied;
            _signedEnemies.Add(enemy);
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;

        if (_signedEnemies.Contains(enemy) == true)
            _signedEnemies.Remove(enemy);

        Spawn(enemy.transform);
    }

    private void Spawn(Transform point)
    {
        if (TryGetCoin(out Coin coin))
        {
            coin.gameObject.SetActive(true);
            coin.transform.position = new Vector3(point.position.x, point.position.y + _offsetY, point.position.z);
        }
    }

    public void Restart()
    {
        ResetPool();
    }
}
