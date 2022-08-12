using UnityEngine;

public class ShorteningDistanceTransition : Transition
{
    [SerializeField] private float _minDistanceToTarget;
    [SerializeField] private float _maxRange;

    private void Start()
    {
        _minDistanceToTarget += Random.Range(-_maxRange, _maxRange);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) <= _minDistanceToTarget)
        {
            NeedTransit = true;
        }
    }
}
