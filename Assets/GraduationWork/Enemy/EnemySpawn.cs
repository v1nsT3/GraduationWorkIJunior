using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private ParticleSystem _spawnEffectTempate;

    private ParticleSystem _currentEffect;
    private float _offsetY = 0.1f;

    private void Awake()
    {
        _currentEffect = Instantiate(_spawnEffectTempate);
    }

    private void OnEnable()
    {
        _currentEffect.transform.position = transform.position + new Vector3(0, _offsetY, 0);
        _currentEffect.transform.rotation = Quaternion.identity;
        _currentEffect.Play();
    }
}
