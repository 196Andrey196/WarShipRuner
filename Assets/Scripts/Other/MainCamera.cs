using UnityEngine;

public class MainCamera : MonoBehaviour
{

  [SerializeField] private Transform _player;
  private Vector3 _playerPosition;

  private float _cameraOffset = 4.5f;
  private float _smoothSpeed = 5f;

  private void LateUpdate()
  {
    _playerPosition = _player.transform.position;
    Vector3 desiredPosition = new Vector3(_playerPosition.x, transform.position.y, _playerPosition.z - _cameraOffset);

    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);

    transform.position = smoothedPosition;
  }

}
