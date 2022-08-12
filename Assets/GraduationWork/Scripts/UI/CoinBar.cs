using TMPro;
using UnityEngine;

public class CoinBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _coins;

    private void OnEnable()
    {
        _player.CoinsChanged += OnChangedCoins;
        OnChangedCoins(_player.Coins);
    }

    private void OnDisable()
    {
        _player.CoinsChanged -= OnChangedCoins;
    }

    private void OnChangedCoins(int value)
    {
        _coins.text = value.ToString();
    }
}
