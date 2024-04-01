using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet instance;
    [SerializeField] private TextMeshProUGUI _coinCounter;
    [SerializeField] private PlayerData _playerData;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    public void AddMoneyInWallet(float cost)
    {
        if (cost != 0 && cost > 0)
        {
            _playerData.currentCoinsInWallet += cost;
            UpdateCoinsCounter();

        }
    }
    public void SpendCoins(float cost)
    {
        if (cost <= _playerData.currentCoinsInWallet)
        {
            _playerData.currentCoinsInWallet -= cost;
            UpdateCoinsCounter();
        }
    }
    public void UpdateCoinsCounter()
    {
        _coinCounter.text = _playerData.currentCoinsInWallet.ToString();
    }
}
