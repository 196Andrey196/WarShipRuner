using System;
using UnityEngine;

public class ObstacleDeathManager : MonoBehaviour
{
    private MainHealthManager _mainHealthManager;
    private MainObjectData _mainObjectData;
    private void Awake()
    {
        _mainHealthManager = GetComponent<MainHealthManager>();
        _mainObjectData = GetComponent<MainObjectData>();
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
        SoundManager.instance.DestroySoundEfects(_mainObjectData.destroySound, 0.1f);
        Destroy(gameObject);
    }
}
