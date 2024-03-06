using UnityEngine;

public class DetectObjectInRadius : MonoBehaviour
{
    [SerializeField] private float circleRadius = 2f;
    private ExplosionAndDamage _explosionAndDamage;

    private void Start()
    {
        _explosionAndDamage = GetComponent<ExplosionAndDamage>();
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, circleRadius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                _explosionAndDamage.explosionContact?.Invoke(collider.gameObject);
            }
        }
    }
}
