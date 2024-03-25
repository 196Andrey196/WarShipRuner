using System;
using UnityEngine;

public class PickUpBonus : MonoBehaviour
{
    public Action<GameObject> pickUpBonus;
    private void OnEnable()
    {
        pickUpBonus += PickUp;
    }
    private void OnDisable()
    {
        pickUpBonus -= PickUp;
    }

    private void PickUp(GameObject bonus)
    {
        IBonus iBonus = bonus.GetComponent<IBonus>();
        if (iBonus != null)
        {
            iBonus.Activate();
        }
        else
        {
            Debug.LogWarning("The picked up bonus does not implement IBonus interface.");
        }
    }

}
