using System.Collections;
using UnityEngine;
using DG.Tweening;

public class SpawnState : State
{
    [SerializeField] private ParticleSystem _spawnEffectTemplate;
    [SerializeField] private float _delaySpawn;
    [SerializeField] private float _targetPositionY;

    private ParticleSystem _currentEffect;
    private float _offsetY;
    

    public ParticleSystem SpawnEffect => _currentEffect;

    private void Awake()
    {
        _currentEffect = Instantiate(_spawnEffectTemplate, transform);
    }

    private void OnEnable()
    {
        _currentEffect.transform.position = transform.position + new Vector3(0, _offsetY, 0);
        _currentEffect.transform.rotation = Quaternion.identity;
        _currentEffect.Play();

        transform.DOMoveY(transform.position.y - _targetPositionY, _delaySpawn).From();
    }
}
