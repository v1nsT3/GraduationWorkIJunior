using TMPro;
using UnityEngine;

public class CoinBar : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TMP_Text _coins;

    private void OnEnable()
    {
        _playerWallet.CoinsChanged += OnChangedCoins;
        OnChangedCoins(_playerWallet.Coins);
    }

    private void OnDisable()
    {
        _playerWallet.CoinsChanged -= OnChangedCoins;
    }

    private void OnChangedCoins(int value)
    {
        _coins.text = value.ToString();
    }
}
