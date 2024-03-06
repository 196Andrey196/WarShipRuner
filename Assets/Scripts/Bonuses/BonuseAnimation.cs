using UnityEngine;

public class BonuseAnimation : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minChangePositionSpeed;
    [SerializeField] private float _maxChangePositionSpeed;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }
    void Update()
    {
        AnimateBonus();
    }
    private void AnimateBonus()
    {
        transform.Rotate(Vector3.right * _rotationSpeed * Time.deltaTime);


        float newY = Mathf.PingPong(Time.time * _moveSpeed, _maxChangePositionSpeed - _minChangePositionSpeed) + _minChangePositionSpeed;

        transform.position = new Vector3(initialPosition.x, newY + initialPosition.y, initialPosition.z);
    }
}
