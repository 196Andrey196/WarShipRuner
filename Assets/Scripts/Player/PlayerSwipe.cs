using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwipe : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private float _swipeThreshold;
    [SerializeField] private float _sensitivityScale;
    [SerializeField] private float _maxSwipeMagnitude;
    [SerializeField] private Vector2 _swipeDirection;
    private Vector2 _startTouchPosition;
    [SerializeField] private bool _touchOnScreen;
    public bool touchOnScreen { get { return _touchOnScreen; } }

    public event Action<Vector2, float> onSwipe;

    private void Awake()
    {
        _touchOnScreen = false;
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
        Swipe();

        onSwipe?.Invoke(_swipeDirection, _maxSwipeMagnitude);
    }

    private void Swipe()
    {
        Vector2 scaledSwipeDirection = _swipeDirection * _sensitivityScale;

        if (scaledSwipeDirection.magnitude < _swipeThreshold)
        {
            scaledSwipeDirection = Vector2.zero;
        }

    }

}

