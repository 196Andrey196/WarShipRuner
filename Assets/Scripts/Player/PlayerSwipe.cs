using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwipe : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private float _swipeThreshold;
    [SerializeField] private float _sensitivityScale;
    [SerializeField] private float _minLerpSpeed;
    [SerializeField] private float _maxLerpSpeed;
    [SerializeField] private float _maxSwipeMagnitude;
    [SerializeField] private Vector2 _swipeDirection;
    private Vector2 _startTouchPosition;
    private float _axeValue;
    public bool _touchOnScreen;
    private Animator _animator;
    private SplineFollower _splineFollower;

    private void Awake()
    {
        _splineFollower = GetComponent<SplineFollower>();
        _touchOnScreen = false;
        _axeValue = 0f;
        _animator = GetComponent<Animator>();
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {

        _playerInput.Player.TouchPosition.started += ctx => SetTouchPosition(ctx);
        _playerInput.Player.SwipePosition.performed += ctx => OnSwipeUpdated(ctx);
        _playerInput.Player.TouchContact.performed += ctx => _touchOnScreen = true;
        _playerInput.Player.TouchContact.canceled += ctx => _touchOnScreen = false;


        _playerInput.Player.Enable();

    }


    private void OnDisable()
    {
        _playerInput.Player.Disable();
    }


    private void SetTouchPosition(InputAction.CallbackContext ctx)
    {
        _startTouchPosition = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
    }
    private void OnSwipeUpdated(InputAction.CallbackContext ctx)
    {
        Vector2 currentSwipePosition = ctx.ReadValue<Vector2>();

        _swipeDirection = currentSwipePosition - _startTouchPosition;
        Move();
    }

    private void Move()
    {

        if (!_touchOnScreen)
        {
            _axeValue = 0f;
        }

        Vector2 scaledSwipeDirection = _swipeDirection * _sensitivityScale;


        if (scaledSwipeDirection.magnitude < _swipeThreshold)
        {
            scaledSwipeDirection = Vector2.zero;
        }

        float targetOffsetX = _splineFollower.offsetModifier.keys[0].offset.x + scaledSwipeDirection.x;
        float clampedX = Mathf.Clamp(targetOffsetX, -3f, 3f);
        float dynamicLerpSpeed = Mathf.Lerp(_minLerpSpeed, _maxLerpSpeed, Mathf.InverseLerp(0, _maxSwipeMagnitude, scaledSwipeDirection.magnitude));
        _axeValue = Mathf.Lerp(_axeValue, clampedX, dynamicLerpSpeed * Time.deltaTime);
        _splineFollower.offsetModifier.keys[0].offset.x = _axeValue;
        _animator.SetFloat("AxeX", _axeValue);

    }

}

