using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private MainObjectData _boatData;
    public MainObjectData boatData { get { return _boatData; } }
    private List<LevelData> _levelsData;
    public List<LevelData> levelsData { get { return _levelsData; } }

    private void Awake()
    {
        _boatData = GetComponent<MainObjectData>();
        _levelsData = _boatData.levelsList;
        SetParametersForLevel();
    }
    private void Start()
    {
        for (int i = 0; i < _boatData.currentLevelId + 1; i++)
        {
            ActivateSoldier(_levelsData[_boatData.currentLevelId].maxSoldiers);
        }
    }
    public void ActivateSoldier(float solderOnBoat)
    {
        Transform soldiersParent = transform.GetChild(1);
        if (soldiersParent != null && solderOnBoat > 0)
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
    public void SetParametersForLevel()
    {
        if (_boatData.currentLevelId < _levelsData.Count)
        {

            _boatData.health = _levelsData[_boatData.currentLevelId].health;
            _boatData.currentHealth = _levelsData[_boatData.currentLevelId].health;
            _boatData.fireCooldown = _levelsData[_boatData.currentLevelId].fireCooldown;
        }
    }
    public bool CheckCurrentLevel()
    {
        if (_boatData.currentLevelId == _levelsData.Count - 1) return true;
        return false;
    }
}
