using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    [SerializeField] private float _health;
    public float health { get { return _health; } }
    [SerializeField] private float _fireCooldown;
    public float fireCooldown { get { return _fireCooldown; } }
    [SerializeField] private int _maxSoldiers;
    public int maxSoldiers { get { return _maxSoldiers; } }
    [SerializeField] private float _upgradeCost;
    public float upgradeCost { get { return _upgradeCost; } }
    [SerializeField] private int _levelId;
    public int levelId { get { return _levelId; } }
}