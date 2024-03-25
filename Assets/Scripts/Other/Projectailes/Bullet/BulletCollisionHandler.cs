using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    private PoolManager _poolManager;
    private ProjectileData _projectileData;

    private void Start()
    {
        _projectileData = GetComponent<ProjectileData>();

        if (_projectileData != null && _projectileData.parentObject != null)
        {
            _poolManager = _projectileData.parentObject.GetComponent<ProjectileLauncher>().poolManager;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Player")
        {
            HandleCollision(collision.gameObject);
        }
    }


    public void HandleCollision(GameObject hitedObject)
    {
        if (hitedObject && gameObject.activeSelf)
        {
            MainHealthManager _healthManager = hitedObject.GetComponent<MainHealthManager>();
            _healthManager.takeDamage?.Invoke(_projectileData.damage);
            _poolManager.Release(gameObject);
        }
    }
}
