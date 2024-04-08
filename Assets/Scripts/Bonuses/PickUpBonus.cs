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
        BonusData bonusData = bonus.GetComponent<BonusData>();
        if (iBonus != null)
        {
            SoundManager.instance.PlaySoundEfects(bonusData.pickUpSound,0.3f);
            iBonus.Activate();
        }
        else
        {
            Debug.LogWarning("The picked up bonus does not implement IBonus interface.");
        }
    }

}
