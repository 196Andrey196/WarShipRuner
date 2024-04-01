using UnityEngine;

public class PlayerData : MainObjectData
{
    [SerializeField] private int _currentLevelId;
    public int currentLevelId
    {
        get { return _currentLevelId; }
        set { if (value > 0) _currentLevelId = value; }
    }
    [SerializeField] private float _currentCoinsInWallet;

    public float currentCoinsInWallet
    {
        get { return _currentCoinsInWallet; }
        set { if (value > 0) _currentCoinsInWallet = value; }
    }
}
