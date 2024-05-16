using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(UfoMove))]
public class Ufo : MonoBehaviour, IDamageable
{
    private SpriteRenderer _spriteRenderer;
    private ParticleSystem _particleSystem;
    private BoxCollider2D _collider;
    private UfoMove _ufoMove;
    private int _life;
    private int _score;
    private Vector2 _startPosition;

    public event Action<int> Died;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _particleSystem = GetComponent<ParticleSystem>();
        _collider = GetComponent<BoxCollider2D>();
        _ufoMove = GetComponent<UfoMove>();
    }

    public void SetData(UfoData ufoData)
    {
        _life = ufoData.Life;
        _score = ufoData.Score;
        _startPosition = new Vector2(ufoData.StartPositionX, ufoData.PositionY);
        _ufoMove.SetPositionX(ufoData.EndPositionX);
        _ufoMove.Run();
    }

    public void ApplyDamage()
    {
        _life--;

        if (_life < 1)
        {
            Died?.Invoke(_score);
            _spriteRenderer.enabled = false;
            _collider.enabled = false;
            _particleSystem.Play();
        }
    }

    public void Restore()
    {
        transform.gameObject.SetActive(true);
        _spriteRenderer.enabled = true;
        _collider.enabled = true;
        transform.position = _startPosition;
        _particleSystem.Stop();
        _ufoMove.Stop();
        _ufoMove.Run();
    }
}
