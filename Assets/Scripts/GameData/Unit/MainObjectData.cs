using System;
using UnityEngine;

public class MainObjectData : MonoBehaviour
{

    [SerializeField] private float _health;
    [SerializeField] private AudioClip _destroySound;
    [SerializeField] private float _collisionDamage;
    public float collisionDamage { get { return _collisionDamage; } }
    [SerializeField] private float _currentHealth;
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
