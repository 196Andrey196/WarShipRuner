using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;
    [SerializeField] GameObject _player;
    [SerializeField] private UpgradeInfo _upgradeInfo;
    private PlayerData _playerData;
    public PlayerData playerData { get { return _playerData; } }
    [SerializeField] private List<LevelData> _levelsData;
    public List<LevelData> levelsData { get { return _levelsData; } }



    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        _playerData = _player.GetComponent<PlayerData>();
    }
    private void Start()
    {
        SetParametersForLevel();
        for (int i = 0; i < _playerData.currentLevelId + 1; i++)
        {
            ActivateSoldier(_levelsData[_playerData.currentLevelId].maxSoldiers);
        }
    }
    private void ActivateSoldier(float solderOnBoat)
    {
        Transform soldiersParent = _player.transform.GetChild(1);
        if (soldiersParent != null)
        {
            for (int i = 0; i < solderOnBoat; i++)
            {
                GameObject child = soldiersParent.GetChild(i).gameObject;

                if (!child.activeSelf)
                {
                    child.SetActive(true);
                    break;
                }
            }
        }
    }
    private void SetParametersForLevel()
    {
        if (_playerData.currentLevelId < _levelsData.Count && _playerData.currentCoinsInWallet > _levelsData[_playerData.currentLevelId].upgradeCost)
        {

            _playerData.health = _levelsData[_playerData.currentLevelId].health;
            _playerData.currentHealth = _levelsData[_playerData.currentLevelId].health;
            _playerData.fireCooldown = _levelsData[_playerData.currentLevelId].fireCooldown;
            _upgradeInfo.UpdateUI();
        }
    }
    public void UpgradePlayer()
    {
        if (playerData.currentLevelId < _levelsData.Count - 1)
        {
            _playerData.currentLevelId++;
            ActivateSoldier(_levelsData[_playerData.currentLevelId].maxSoldiers);
            SetParametersForLevel();
            float costUpgrade = _levelsData[_playerData.currentLevelId].upgradeCost;
            Wallet.instance.SpendCoins(costUpgrade);
        }


    }
    public bool CheckCurrentLevel()
    {
        if (_playerData.currentLevelId == _levelsData.Count - 1) return true;
        return false;
    }
}
