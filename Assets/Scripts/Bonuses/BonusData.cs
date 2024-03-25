using UnityEngine;

public class BonusData : MonoBehaviour
{
    [SerializeField] private float _cost;
    public float cost { get { return _cost; } }
    [SerializeField] private AudioClip _pickUpSound;
    public AudioClip pickUpSound { get { return _pickUpSound; } }

}
