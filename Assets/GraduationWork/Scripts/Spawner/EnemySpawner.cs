using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : EnemyPool
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Enemy _enemyTemplate;

    private List<Enemy> _signedEnemies = new List<Enemy>();
    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private float _lastTimeSpawned;
    private int _numberOfSpawned = 0;
    private int _numberEnemyDied;
    private int _maxNumbersSpawn;

    public event UnityAction AllEnemyDied;
    public event UnityAction<float, float> EnemyDied;
    public event UnityAction<Enemy> EnemySpawned;

    private void Awake()
    {
        FillPool(_enemyTemplate);
        SetWave(_currentWaveIndex);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _lastTimeSpawned += Time.deltaTime;

        if (_lastTimeSpawned >= _currentWave.Delay)
        {
            _lastTimeSpawned = 0;

            if (TryGetEnemy(out Enemy enemy))
            {
                Spawn(enemy, _spawnPoints[Random.Range(0, _spawnPoints.Count)]);
            }

            _numberOfSpawned++;
        }

        if (_numberOfSpawned >= _currentWave.Count)
            _currentWave = null;
    }

    public void NextWave()
    {
        if(_currentWaveIndex + 1 <= _waves.Count - 1)
        {
            SetWave(++_currentWaveIndex);
        }
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        _numberEnemyDied = 0;
        _maxNumbersSpawn = _currentWave.Count;
        _numberOfSpawned = 0;

        EnemyDied?.Invoke(_numberEnemyDied, _currentWave.Count);
    }

    private void Spawn(Enemy enemy, Transform spawnPoint)
    {
        if(_signedEnemies.Contains(enemy) == false)
        {
            enemy.Died += OnEnemyDied;
            _signedEnemies.Add(enemy);
        }

        enemy.transform.position = spawnPoint.position;
        enemy.gameObject.SetActive(true);
        EnemySpawned?.Invoke(enemy);
        enemy.Restart();
    }

    private void OnEnemyDied(Enemy enemy)
    {
        if (_signedEnemies.Contains(enemy) == true)
        {
            enemy.Died -= OnEnemyDied;
            _signedEnemies.Remove(enemy);
        }

        _numberEnemyDied++;

        EnemyDied?.Invoke(_numberEnemyDied, _maxNumbersSpawn);

        if(_numberEnemyDied == _maxNumbersSpawn)
            AllEnemyDied?.Invoke();
    }

    public void Restart()
    {
        ResetPool();
        _currentWaveIndex = 0;
        SetWave(_currentWaveIndex);
    }
}
