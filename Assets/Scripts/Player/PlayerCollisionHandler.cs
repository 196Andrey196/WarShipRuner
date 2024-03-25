using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    private MainHealthManager _healthManager;
    private GameObject _collideWithObstacle;
    public Action<GameObject> onCollision;

    private void Start()
    {
        _healthManager = GetComponent<MainHealthManager>();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision != null && collision.tag == "Bonus")
        {
            PickUpBonus bonus = collision.GetComponent<PickUpBonus>();
            bonus.pickUpBonus?.Invoke(collision.gameObject);
        }
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