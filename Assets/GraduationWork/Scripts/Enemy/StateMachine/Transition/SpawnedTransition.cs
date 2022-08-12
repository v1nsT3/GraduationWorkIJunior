using UnityEngine;

public class SpawnedTransition : Transition
{
    [SerializeField] private SpawnState _spawnState;

    private void Update()
    {
        if (_spawnState.SpawnEffect.isPlaying == false)
            NeedTransit = true;
    }
}
