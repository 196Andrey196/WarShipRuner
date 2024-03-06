using UnityEngine;

public class ObstacleCollisionHandler : MonoBehaviour
{
    private HealthManager _healthManager;
    private void Start()
    {
        _healthManager = GetComponent<HealthManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
        {
            HandleCollision(collision.gameObject);
        }
    }



    public void HandleCollision(GameObject hitedObject)
    {
        if (hitedObject)
        {
                float hitDamge = hitedObject.GetComponent<MainObjectData>().collisionDamage;
                _healthManager.takeDamage?.Invoke(hitDamge);
        }
    }
}
