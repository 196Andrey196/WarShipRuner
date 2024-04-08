using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{
    public static PlayerUpgradeManager instance;
    [SerializeField] private UpgradeInfo _upgradeInfo;
    [SerializeField] private GameObject _player;
    private UpgradeManager _upgradeManager;
    private PlayerData _playerData;
    public PlayerData playerData { get { return _playerData; } }

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
        _upgradeManager = _player.GetComponent<UpgradeManager>();
        _playerData = _player.GetComponent<PlayerData>();
        _upgradeInfo.UpdateUI();
    }
    public void UpgradePlayer()
    {
        Debug.Log("_playerData.currentLevelId = " + _playerData.currentLevelId);
        Debug.Log("_levelsData.Count = " + (_playerData.levelsList.Count - 1));
        if (_playerData.currentLevelId < _playerData.levelsList.Count - 1)
        {
            _playerData.currentLevelId++;
            _upgradeManager.ActivateSoldier(_playerData.levelsList[_playerData.currentLevelId].maxSoldiers);
            _upgradeManager.SetParametersForLevel();
            float costUpgrade = _playerData.levelsList[_playerData.currentLevelId].upgradeCost;
            Wallet.instance.SpendCoins(costUpgrade);
            _upgradeInfo.UpdateUI();
        }
    }
}
