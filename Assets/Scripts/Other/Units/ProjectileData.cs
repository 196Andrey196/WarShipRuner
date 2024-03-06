using UnityEngine;

public class ProjectileData : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float speed { get { return _speed; } }
    [SerializeField] private float _damage;
    public float damage { get { return _damage; } }
    [SerializeField] private float _maxFlightDistance;
    public float maxFlightDistance { get { return _maxFlightDistance; } }
    public GameObject parentObject;
}
