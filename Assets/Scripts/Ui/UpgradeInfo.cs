using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfo : MonoBehaviour
{
    [SerializeField] private UpgradeManager _playerUpgradeManager;

    [Header("Current Values")]
    [SerializeField] private TextMeshProUGUI _healthCount;
    [SerializeField] private TextMeshProUGUI _solderCount;
    [SerializeField] private TextMeshProUGUI _fireCooldownCount;
    [Header("New Values After Upgrade")]
    [SerializeField] private TextMeshProUGUI _newHealthCount;
    [SerializeField] private TextMeshProUGUI _newSolderCount;
    [SerializeField] private TextMeshProUGUI _newFireCooldownCount;
    [Header("")]
    [SerializeField] private TextMeshProUGUI _upgradeCost;
    [SerializeField] private Button _upgradeButton;


    private void Start()
    {
        _upgradeButton = transform.parent.transform.GetChild(1).GetComponent<Button>();
        UpdateUI();
    }
    public void UpdateUI()
    {
        SetParameters(_healthCount, _solderCount, _fireCooldownCount, _playerUpgradeManager.boatData.currentLevelId);
        int nextLevelId = _playerUpgradeManager.boatData.currentLevelId + 1;
        if (nextLevelId < _playerUpgradeManager.levelsData.Count)
        {
            SetParameters(_newHealthCount, _newSolderCount, _newFireCooldownCount, nextLevelId);
        }
        else
        {
            SetMaxValues(_newHealthCount, _newSolderCount, _newFireCooldownCount);
        }
    }

    private void SetMaxValues(TextMeshProUGUI health, TextMeshProUGUI maxSoldier, TextMeshProUGUI fireCooldown)
    {
        health.text = "Max";
        maxSoldier.text = "Max";
        fireCooldown.text = "Max";
        _upgradeCost.text = "Max";
        _upgradeButton.interactable = false;
    }
    private void SetParameters(TextMeshProUGUI health, TextMeshProUGUI maxSoldier, TextMeshProUGUI fireCooldown, int setLevel)
    {
        if (setLevel >= 0 && setLevel < _playerUpgradeManager.levelsData.Count)
        {
            CheckStatsOnNextLevel(health, _playerUpgradeManager.levelsData[setLevel].health, setLevel);
            CheckStatsOnNextLevel(maxSoldier, _playerUpgradeManager.levelsData[setLevel].maxSoldiers, setLevel);
            CheckStatsOnNextLevel(fireCooldown, _playerUpgradeManager.levelsData[setLevel].fireCooldown, setLevel);
            _upgradeCost.text = _playerUpgradeManager.levelsData[setLevel].upgradeCost.ToString();
        }
    }
    private void CheckStatsOnNextLevel(TextMeshProUGUI uiText, float value, int levelId)
    {
        if (uiText != null && value > 0 && levelId < _playerUpgradeManager.levelsData.Count) uiText.text = value.ToString();
    }


}
