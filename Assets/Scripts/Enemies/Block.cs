using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(BoxCollider2D))]
public class Block : MonoBehaviour, IDamageable
{
    private SpriteRenderer _spriteRenderer;
    private ParticleSystem _particleSystem;
    private BoxCollider2D _collider;
    private List<Sprite> _sprites;
    private int _score;
    private int _life;

    public event Action<int> Died;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _particleSystem = GetComponent<ParticleSystem>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        _particleSystem.Stop();
    }

    public void SetData(BlockData blockData)
    {
        int countOfSprites = blockData.GetSpritesCount();
        _sprites = new List<Sprite>();

        for (int i = 0; i < countOfSprites; i++)
        {
            _sprites.Add(blockData.GetSprite(i));
        }

        _score = blockData.Score;
        _spriteRenderer.color = blockData.BaseColor;
        _life = _sprites.Count;
        _spriteRenderer.sprite = _sprites[_life - 1];
        ParticleSystem.MainModule main = _particleSystem.main;
        main.startColor = blockData.BaseColor;
    }

    public void ApplyDamage()
    {
        _life--;

        if(_life < 1)
        {
            _spriteRenderer.enabled = false;
            _collider.enabled = false;
            _particleSystem.Play();
            Died?.Invoke(_score);
        }
        else
        {
            _spriteRenderer.sprite = _sprites[_life - 1];
        }
    }

    public void Restore()
    {
        transform.gameObject.SetActive(true);
        _spriteRenderer.enabled = true;
        _collider.enabled = true;
        _life = _sprites.Count;
        _spriteRenderer.sprite = _sprites[_life - 1];
    }
}
