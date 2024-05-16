using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerInput : MonoBehaviour
{
    private Finger _movementFinger;
    private Vector2 _startPosition;

    public float Direction {  get; private set; }
    public bool IsTouch {  get; private set; }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += OnFingerDown;
        ETouch.Touch.onFingerUp += OnFingerUp;
        ETouch.Touch.onFingerMove += OnFingerMove;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= OnFingerDown;
        ETouch.Touch.onFingerUp -= OnFingerUp;
        ETouch.Touch.onFingerMove -= OnFingerMove;
        EnhancedTouchSupport.Disable();
    }

    public void OnFingerMove(Finger finger)
    {
        if (finger == _movementFinger)
        {
            Direction = finger.screenPosition.x > _startPosition.x ? 1 : -1;
        }
    }

    public void OnFingerUp(Finger finger)
    {
        if (finger == _movementFinger)
        {
            Direction = 0f;
            _movementFinger = null;
        }
    }

    public void OnFingerDown(Finger finger)
    {
        if (_movementFinger == null)
        {
            IsTouch = true;
            Direction = 0f;
            _movementFinger = finger;
            _startPosition = finger.screenPosition;
        }
    }
}
