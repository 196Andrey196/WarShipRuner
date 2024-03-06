using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _startMovePosition;

    private PoolManager _poolManager;
    private ProjectileData _projectileData;



    private void Start()
    {
        _projectileData = GetComponent<ProjectileData>();
        _poolManager = _projectileData.parentObject.GetComponent<ProjectileLauncher>().poolManager;
    }

    void Update()
    {
        _startMovePosition = _projectileData.parentObject.transform.position;
        MoveBullet();
    }
    private void MoveBullet()
    {
        transform.Translate(Vector3.forward * _projectileData.speed * Time.deltaTime);
        if (CheckDistanceFromParent() >= _projectileData.maxFlightDistance)
        {
            _poolManager.Release(gameObject);
        }
    }
    private float CheckDistanceFromParent()
    {

        return Vector3.Distance(_startMovePosition, transform.position);
    }


}
