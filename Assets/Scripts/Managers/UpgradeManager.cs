using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;
    [SerializeField] GameObject _playerData;
    [SerializeField] private UpgradeInfo _upgradeInfo;
    private MainObjectData _mainObjectData;
    [SerializeField] private List<LevelData> _levelsData;
    public List<LevelData> levelsData { get { return _levelsData; } }
    [SerializeField] private int _currentLevelId;
    public int currentLevelId { get { return _currentLevelId; } set { if (value < _levelsData.Count - 1) _currentLevelId = value; } }

    public Action upgrade;
    private void OnEnable()
    {
        upgrade += SetParametersForLevel;
    }
    private void OnDisable()
    {
        upgrade += SetParametersForLevel;
    }


    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        _mainObjectData = _playerData.GetComponent<MainObjectData>();

    }
    private void ActiveSoldier()
    {

        Transform soldiersParent = _playerData.transform.GetChild(1);
        if (soldiersParent != null)
        {
            int soldierOnBoat = _levelsData.Count;
            for (int i = 0; i < soldierOnBoat; i++)
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
        if (_currentLevelId < _levelsData.Count - 1 && Wallet.instance.currentCoinsInWallet > _levelsData[_currentLevelId].upgradeCost)
        {
            _currentLevelId++;
            _upgradeInfo.updateUiInfo?.Invoke();
            _mainObjectData.health = _levelsData[_currentLevelId].health;
            _mainObjectData.currentHealth = _levelsData[_currentLevelId].health;
            _mainObjectData.fireCooldown = _levelsData[_currentLevelId].fireCooldown;
            float costUpgrade = _levelsData[_currentLevelId].upgradeCost;
            Wallet.instance.SpendCoins(costUpgrade);
            Debug.Log("SetPatameters Level = " + (_currentLevelId + 1));
        }
        else Debug.Log("You can't upgrade level");
    }




}
