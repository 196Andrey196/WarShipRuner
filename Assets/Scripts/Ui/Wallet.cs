using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet instance;
    [SerializeField] private TextMeshProUGUI _coinCounter;
    [SerializeField] private float _currentCoinsInWallet;
    public float currentCoinsInWallet { get { return _currentCoinsInWallet; } }

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

    }
    private void Start()
    {
        UpdateCoinsCounter();
    }
    public void AddMoneyInWallet(float cost)
    {
        if (cost != 0 && cost > 0)
        {
            _currentCoinsInWallet += cost;
            UpdateCoinsCounter();

        }
    }
    public void SpendCoins(float cost)
    {
        if (cost <= _currentCoinsInWallet)
        {
            _currentCoinsInWallet -= cost;
            UpdateCoinsCounter();
        }
    }
    private void UpdateCoinsCounter()
    {
        _coinCounter.text = _currentCoinsInWallet.ToString();
    }
}
