using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _restartScreen;


    private void OnEnable()
    {
        _player.Died += GameOver;
    }

    private void OnDisable()
    {
        _player.Died -= GameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void Play()
    {
        Restart();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        _enemySpawner.Restart();
        _player.Restart();
        _coinSpawner.Restart();
    }

    private void GameOver()
    {
        _restartScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
