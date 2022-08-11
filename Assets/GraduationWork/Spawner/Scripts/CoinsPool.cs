using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class CoinsPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private List<Coin> _coins = new List<Coin>();

    protected void FillPool(Coin prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Coin coin = Instantiate(prefab, Vector3.zero, prefab.transform.rotation, _container);
            _coins.Add(coin);
            coin.gameObject.SetActive(false);
        }
    }

    protected bool TryGetCoin(out Coin coin)
    {
        coin = _coins.FirstOrDefault(e => e.gameObject.activeSelf == false);

        return coin != null;
    }

    protected void ResetPool()
    {
        foreach (var coin in _coins)
            coin.gameObject.SetActive(false);
    }
}
