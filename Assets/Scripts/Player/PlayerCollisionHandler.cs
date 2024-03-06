using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    private HealthManager _healthManager;
    [SerializeField] private GameObject _collideWithObstacle;

    private void Start()
    {
        _healthManager = GetComponent<HealthManager>();
    }


    private void OnTriggerEnter(Collider collision)
    {
        // if (collision != null && collision.tag == "Bonus")
        // {
        //     HandleCollision(collision.gameObject);
        // }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.tag == "Obstacle")
        {
            HandleCollision(collision.gameObject);
        }
    }



    public void HandleCollision(GameObject hitedObject)
    {
        if (hitedObject)
        {
            _collideWithObstacle = hitedObject;
            float hitDamge = hitedObject.GetComponent<MainObjectData>().collisionDamage;
            _healthManager.takeDamage?.Invoke(hitDamge);
        }
    }
}