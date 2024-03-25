using UnityEngine;
using UnityEngine.UI;

public class HealthManagerUI : MonoBehaviour
{
    [SerializeField] private Image _health;
    private MainObjectData _mainObjectData;
    private void Start()
    {
        _mainObjectData = GetComponent<MainObjectData>();
        if (_mainObjectData) UpdateHealthUI();
    }
    private void Update()
    {
        if (_mainObjectData)
            UpdateHealthUI();
    }
    private void UpdateHealthUI()
    {
        if (_mainObjectData.health != 0)
        {
            _health.fillAmount = _mainObjectData.currentHealth / _mainObjectData.health;
        }
    }
}
