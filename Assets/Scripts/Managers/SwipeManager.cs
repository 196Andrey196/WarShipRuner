using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeManager : MonoBehaviour
{
    public static SwipeManager instance;
    private PlayerInput _playerInput;
    [SerializeField] private float _swipeThreshold;
    [SerializeField] private float _sensitivityScale;
    [SerializeField] private float _maxSwipeMagnitude;
    [SerializeField] private Vector2 _swipeDirection;
    private Vector2 _startTouchPosition;
    [SerializeField] private bool _touchOnScreen;
    public bool touchOnScreen { get { return _touchOnScreen; } }

    public Action<Vector2, float> onSwipe;
    public Action playerSwipe;

    private void Awake()
    {
        _touchOnScreen = false;
        _playerInput = new PlayerInput();
        if (instance != null)
        {
            return;
        }
        instance = this;
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
        Swipe();
        Vector2 currentSwipePosition = ctx.ReadValue<Vector2>();
        _swipeDirection = currentSwipePosition - _startTouchPosition;
        onSwipe?.Invoke(_swipeDirection, _maxSwipeMagnitude);
    }

    private void Swipe()
    {
        playerSwipe?.Invoke();
        Vector2 scaledSwipeDirection = _swipeDirection * _sensitivityScale;

        if (scaledSwipeDirection.magnitude < _swipeThreshold)
        {
            scaledSwipeDirection = Vector2.zero;
        }

    }

}

