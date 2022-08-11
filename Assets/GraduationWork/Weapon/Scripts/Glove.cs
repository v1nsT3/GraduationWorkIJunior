using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Glove : MonoBehaviour
{
    public event UnityAction<Glove, Enemy> HitEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            HitEnemy?.Invoke(this, enemy);
        }
    }
}
