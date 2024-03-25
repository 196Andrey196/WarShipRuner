using System.Collections;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    private PoolManager _poolManager;
    public PoolManager poolManager { get { return _poolManager; } }
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private int _countObjectInPool;
    [SerializeField] private MainObjectData _mainObjectData;
    [SerializeField] private Transform _firePoint;
    private void Start()
    {
        _poolManager = new PoolManager(_projectilePrefab, _countObjectInPool, _firePoint);
        GetParrentObject();
        StartCoroutine(ShootWithInterval());
    }
    private void GetParrentObject()
    {
        Transform currentParent = transform.parent;
        while (currentParent != null)
        {
            MainObjectData parentMainObjectData = currentParent.GetComponent<MainObjectData>();
            if (parentMainObjectData != null)
            {
                _mainObjectData = parentMainObjectData;
                break;
            }
            currentParent = currentParent.parent;
        }
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
            float fireCooldown = _mainObjectData.fireCooldown;
            GameObject obj = _poolManager.GetObject();
            ProjectileData projectile = obj.GetComponent<ProjectileData>();
            projectile.parentObject = gameObject;
            yield return new WaitForSeconds(fireCooldown);
        }
    }



}
