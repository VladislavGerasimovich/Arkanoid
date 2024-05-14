using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private float _moveSpeed;
    private float _borderPosition;
    private Vector2 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
        _borderPosition = 2.65f;
        _moveSpeed = 5f;
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    public void SetStartPosition()
    {
        transform.position = _startPosition;
    }

    private void Move()
    {
        float _positionX = _rigidbody.position.x + _playerInput.Direction * _moveSpeed * Time.deltaTime;
        _positionX = Mathf.Clamp(_positionX, -_borderPosition + (_spriteRenderer.size.x / 2), _borderPosition - (_spriteRenderer.size.x / 2));
        _rigidbody.MovePosition(new Vector2(_positionX, _rigidbody.position.y));
    }
}
