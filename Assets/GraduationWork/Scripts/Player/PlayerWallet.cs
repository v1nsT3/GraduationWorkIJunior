using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private int _coins = 0;

    public int Coins => _coins;

    public event UnityAction<int> CoinsChanged;

    public void AddCoins(int coins)
    {
        _coins += coins;
        CoinsChanged?.Invoke(_coins);
    }

    public void ReduceCoins(int coins)
    {
        _coins -= coins;
        CoinsChanged?.Invoke(_coins);
    }

    public void Restart()
    {
        _coins = 0;
    }
}
