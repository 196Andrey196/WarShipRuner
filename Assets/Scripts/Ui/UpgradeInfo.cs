using System;
using TMPro;
using UnityEngine;

public class UpgradeInfo : MonoBehaviour
{
    [SerializeField] private UpgradeManager _upgradeManager;
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
    public Action updateUiInfo;
    private void OnEnable()
    {
        updateUiInfo += UpdateUI;
    }
    private void OnDisable()
    {
        updateUiInfo -= UpdateUI;
    }

    private void Start()
    {
        UpdateUI();
    }
    private void UpdateUI()
    {
        SetParameters(_healthCount, _solderCount, _fireCooldownCount, _upgradeManager.currentLevelId);
        int nextLevelId = _upgradeManager.currentLevelId + 1;
        if (nextLevelId < _upgradeManager.levelsData.Count)
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
    }
    private void SetParameters(TextMeshProUGUI health, TextMeshProUGUI maxSoldier, TextMeshProUGUI fireCooldown, int setLevel)
    {

        CheckStatsOnNextLevel(health, _upgradeManager.levelsData[setLevel].health, setLevel);
        CheckStatsOnNextLevel(maxSoldier, _upgradeManager.levelsData[setLevel].maxSoldiers, setLevel);
        CheckStatsOnNextLevel(fireCooldown, _upgradeManager.levelsData[setLevel].fireCooldown, setLevel);
        _upgradeCost.text = _upgradeManager.levelsData[setLevel].upgradeCost.ToString();
    }
    private void CheckStatsOnNextLevel(TextMeshProUGUI uiText, float value, int levelId)
    {
        if (uiText != null && value > 0 && levelId < _upgradeManager.levelsData.Count) uiText.text = value.ToString();
    }


}
