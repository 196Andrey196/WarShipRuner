using System;
using UnityEngine;

public class ObstacleDeathManager : MonoBehaviour
{
    private MainHealthManager _mainHealthManager;
    private void Awake()
    {
        _mainHealthManager = GetComponent<MainHealthManager>();
    }
    private void OnEnable()
    {
        _mainHealthManager.objDie += Die;
    }

    private void OnDisable()
    {
        _mainHealthManager.objDie -= Die;
    }

    virtual protected void Die()
    {
        Destroy(gameObject);
    }
}
