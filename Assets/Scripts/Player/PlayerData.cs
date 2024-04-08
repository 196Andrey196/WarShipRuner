using UnityEngine;

public class PlayerData : MainObjectData
{
    [SerializeField] private AudioClip _collisionSound;
    public AudioClip collisionSound { get { return _collisionSound; } }
    [SerializeField] private float _currentCoinsInWallet;

    public float currentCoinsInWallet
    {
        get { return _currentCoinsInWallet; }
        set { if (value > 0) _currentCoinsInWallet = value; }
    }
}
