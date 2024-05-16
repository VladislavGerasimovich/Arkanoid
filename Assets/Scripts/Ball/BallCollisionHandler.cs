using UnityEngine;

[RequireComponent(typeof(BallMove))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(BallSound))]
public class BallCollisionHandler : MonoBehaviour
{
    private BallMove _ballMove;
    private Rigidbody2D _rigidbody;
    private BallSound _ballSound;
    private float _offsetX;

    private void Awake()
    {
        _ballMove = GetComponent<BallMove>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _ballSound = GetComponent<BallSound>();
        _offsetX = 0.1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float ballPositionX = transform.position.x;

        if(collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            if(ballPositionX < _ballMove.LastPositionX + _offsetX && ballPositionX > _ballMove.LastPositionX - _offsetX)
            {
                float collisionPointX = collision.contacts[0].point.x;
                _rigidbody.velocity = Vector2.zero;
                float playerCenterPosition = player.gameObject.GetComponent<Transform>().position.x;
                float difference = playerCenterPosition - collisionPointX;
                float direction = collisionPointX  < playerCenterPosition ? 1 : -1;
                int forceDivider = 2;
                _rigidbody.AddForce(new Vector2(direction * Mathf.Abs(difference * (_ballMove.Force / forceDivider)), _ballMove.Force));
            }

            _ballMove.SetLastPosition(ballPositionX);
        }

        if(collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage();
            _ballSound.PlaySoundCollision();
        }
    }
}
