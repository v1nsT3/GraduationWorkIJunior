using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;
    [SerializeField] private Player _target;

    private List<Enemy> _enemies = new List<Enemy>();


    protected void FillPool(Enemy prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy enemy = Instantiate(prefab, _container);
            enemy.Init(_target);
            _enemies.Add(enemy);
            enemy.gameObject.SetActive(false);
        }
    }

    protected bool TryGetEnemy(out Enemy enemy)
    {
        enemy = _enemies.FirstOrDefault(e => e.gameObject.activeSelf == false);

        return enemy != null;
    }

    protected void ResetPool()
    {
        foreach (var enemy in _enemies)
            enemy.gameObject.SetActive(false);
    }
}
