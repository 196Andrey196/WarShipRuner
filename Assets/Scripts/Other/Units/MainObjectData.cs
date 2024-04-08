using System;
using System.Collections.Generic;
using UnityEngine;

public class MainObjectData : MonoBehaviour
{
    [SerializeField] protected int _currentLevelId;
    public int currentLevelId
    {
        get { return _currentLevelId; }
        set { if (value > 0) _currentLevelId = value; }
    }
    [SerializeField] protected List<LevelData> _levelsList;
    public List<LevelData> levelsList { get { return _levelsList; } }
    [SerializeField] protected float _health;
    public float health
    {
        get { return _health; }
        set { if (value > 0) _health = value; }
    }
    [SerializeField] protected AudioClip _destroySound;
    public AudioClip destroySound { get { return _destroySound; } }
    [SerializeField] protected float _collisionDamage;
    public float collisionDamage { get { return _collisionDamage; } }
    [SerializeField] protected float _currentHealth;
    [SerializeField] protected float _fireCooldown;
    public float fireCooldown
    {
        get { return _fireCooldown; }
        set { if (value > 0) _fireCooldown = value; }
    }
    public float currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, _health); }
    }

    private void Start()
    {
        _currentHealth = _health;
    }

}
