using System;
using UnityEngine;

public class ExplosionAndDamage : MonoBehaviour
{
    private ProjectileData _projectileData;
    public Action<GameObject> explosionContact;
    private PoolManager _poolManager;
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private ParticleSystem _explosionEfect;
    private void OnEnable()
    {
        explosionContact += Explosion;
    }

    private void OnDisable()
    {
        explosionContact -= Explosion;
    }
    void Start()
    {
        _projectileData = GetComponent<ProjectileData>();
        if (_projectileData != null && _projectileData.parentObject != null)
        {
            _poolManager = _projectileData.parentObject.GetComponent<ProjectileLauncher>().poolManager;
        }
    }
    private void Explosion(GameObject obj)
    {
        if (obj != null)
        {
            ParticleSystem explosionVFX = Instantiate(_explosionEfect, transform.position, Quaternion.identity);
            explosionVFX.Play();
            SoundManager.instance.PlaySoundEfects(_explosionSound, 0.4f);
            MainHealthManager _healthManager = obj.GetComponent<MainHealthManager>();
            _healthManager.takeDamage?.Invoke(_projectileData.damage);
            _poolManager.Release(gameObject);

        }
    }

}
