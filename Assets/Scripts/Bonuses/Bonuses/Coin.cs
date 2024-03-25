using System;
using UnityEngine;

public class Coin : MonoBehaviour, IBonus
{
    private BonusData _bonusData;
    private void Start()
    {
        _bonusData = GetComponent<BonusData>();
    }
    public void Activate()
    {
      Wallet.instance.AddMoneyInWallet((int)_bonusData.cost);
      Destroy(gameObject);
    }
}
