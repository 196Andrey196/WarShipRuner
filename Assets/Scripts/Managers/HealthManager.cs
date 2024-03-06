using System;
using TMPro;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _health;
    private MainObjectData _mainObjectData;
    private bool hasDied = false;

    public Action<float> takeDamage;

    private void OnEnable()
    {
        takeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        takeDamage -= TakeDamage;
    }

    private void Start()
    {
        _mainObjectData = GetComponent<MainObjectData>();

    }

    private void Update()
    {
        if (_mainObjectData)
            UpdateHealthUI();
        if (_mainObjectData.currentHealth == 0 && !hasDied)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        _health.text = _mainObjectData.currentHealth.ToString();
    }

    private void TakeDamage(float damage)
    {
        if (damage != 0)
            _mainObjectData.currentHealth -= damage;

        if (_mainObjectData.currentHealth == 0 && !hasDied)
        {
            Die();
        }
    }

    private void Die()
    {
        hasDied = true;
        if (gameObject.CompareTag("Player"))
        {
           
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        } 
    }

}
