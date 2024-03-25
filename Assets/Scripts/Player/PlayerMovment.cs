using Dreamteck.Splines;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Animator _animator;
    private SplineFollower _splineFollower;
    [SerializeField] private float _minLerpSpeed;
    [SerializeField] private float _maxLerpSpeed;
    private float _axeValue;
   private float _animationValue;
    private PlayerSwipe _playerSwipe;
    private void OnEnable()
    {
        _playerSwipe.onSwipe += UpdatePosition;
    }
    private void OnDisable()
    {
        _playerSwipe.onSwipe -= UpdatePosition;

    }

    void Awake()
    {
        _playerSwipe = GetComponent<PlayerSwipe>();
        _splineFollower = GetComponent<SplineFollower>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!_playerSwipe.touchOnScreen) _animationValue = 0;
        _animator.SetFloat("AxeX", _animationValue);
    }

    private void UpdatePosition(Vector2 scaledSwipeDirection, float maxSwipeMagnitude)
    {

        float targetOffsetX = _splineFollower.offsetModifier.keys[0].offset.x + scaledSwipeDirection.x;
        float clampedX = Mathf.Clamp(targetOffsetX, -3f, 3f);
        float dynamicLerpSpeed = Mathf.Lerp(_minLerpSpeed, _maxLerpSpeed, Mathf.InverseLerp(0, maxSwipeMagnitude, scaledSwipeDirection.magnitude));
        _axeValue = Mathf.Lerp(_axeValue, clampedX, dynamicLerpSpeed * Time.deltaTime);
        _animationValue = _axeValue;
        _splineFollower.offsetModifier.keys[0].offset.x = _axeValue;

    }


}
