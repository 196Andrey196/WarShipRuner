using System.Collections;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    private PoolManager _poolManager;
    public PoolManager poolManager { get { return _poolManager; } }
    [SerializeField] private float _fireCooldown;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private int _countObjectInPool;
    [SerializeField] private Transform _firePoint;
    private void Start()
    {
        _poolManager = new PoolManager(_projectilePrefab, _countObjectInPool, _firePoint);
        StartCoroutine(ShootWithInterval());
    }
    private void Update()
    {
        if (_poolManager != null)
            _poolManager.UpdatePoolPosition(_firePoint);
    }

    private IEnumerator ShootWithInterval()
    {

        yield return new WaitForSeconds(1f);
        while (true)
        {
            GameObject obj = _poolManager.GetObject();
            ProjectileData projectile = obj.GetComponent<ProjectileData>();
            projectile.parentObject = gameObject;
            yield return new WaitForSeconds(_fireCooldown);
           
        }
    }



}
