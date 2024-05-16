using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BallSound))]
public class BallMove : MonoBehaviour
{
    private Vector2 _startPosition;
    private BallSound _ballSound;
    private Rigidbody2D _rigidbody;
    private bool _isActive;
    private int _touchCount;

    public float Force {  get; private set; }
    public float LastPositionX {  get; private set; }

    private void Awake()
    {
        _startPosition = transform.position;
        _ballSound = GetComponent<BallSound>();
        _rigidbody = GetComponent<Rigidbody2D>();
        Force = 200f;
    }
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += OnFingerDown;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= OnFingerDown;
        EnhancedTouchSupport.Disable();
    }

    private void Update()
    {
        if(_touchCount > 0 && _isActive == false)
        {
            BallActivate();
        }
    }

    public void SetLastPosition(float position)
    {
        LastPositionX = position;
    }

    public void BallDeactivate()
    {
        transform.position = _startPosition;
        _touchCount = 0;
        _isActive = false;
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        _rigidbody.velocity = Vector2.zero;
    }

    private void BallActivate()
    {
        _ballSound.PlaySoundAwake();
        LastPositionX = transform.position.x;
        _isActive = true;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.AddForce(Vector2.up * Force);
    }

    private void OnFingerDown(Finger finger)
    {
        _touchCount++;
    }
}
