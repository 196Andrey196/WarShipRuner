using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    private MainHealthManager _healthManager;
    public Action<GameObject> onCollision;
    private PlayerData _playerData;

    private void Start()
    {
        _healthManager = GetComponent<MainHealthManager>();
        _playerData = GetComponent<PlayerData>();
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
            SoundManager.instance.PlaySoundEfects(_playerData.collisionSound, 0.3f);
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