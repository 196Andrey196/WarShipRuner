using System;
using UnityEngine;


public class MainHealthManager : MonoBehaviour
{

    private MainObjectData _mainObjectData;
    private bool hasDied = false;

    public Action<float> takeDamage;
    public Action objDie;


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



    private void TakeDamage(float damage)
    {
        if (damage != 0)
            _mainObjectData.currentHealth -= damage;

        if (_mainObjectData.currentHealth == 0 && !hasDied)
        {
            objDie?.Invoke();
        }
    }



}
