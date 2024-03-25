using System;
using UnityEngine;

public class MainObjectData : MonoBehaviour
{

    [SerializeField] private float _health;
    public float health
    {
        get { return _health; }
        set { if (value > 0) _health = value; }
    }
    [SerializeField] private AudioClip _destroySound;
    [SerializeField] private float _collisionDamage;
    public float collisionDamage { get { return _collisionDamage; } }
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _fireCooldown;
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
