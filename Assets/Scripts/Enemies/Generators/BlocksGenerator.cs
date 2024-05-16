using System;
using System.Collections.Generic;
using UnityEngine;

public class BlocksGenerator : MonoBehaviour, IGenerator
{
    [SerializeField] private List<BlockData> _blocks;
    [SerializeField] private float _startPositionX;
    [SerializeField] private float _endPositionX;
    [SerializeField] private float _startPositionY;
    [SerializeField] private float _endPositionY;

    private float _currentPositionX;
    private float _currentPositionY;
    private List<Block> _bricks;

    public event Action<int> ScoreReceived;
    public event Action AllBlocksDied;

    public int BlocksAlife {  get; private set; }

    private void Awake()
    {
        BlocksAlife = _blocks.Count;
        _bricks = new List<Block>();
        _currentPositionX = _startPositionX;
        _currentPositionY = _startPositionY;
    }

    private void OnDisable()
    {
        foreach (Block brick in _bricks)
        {
            brick.Died -= OnDied;
        }
    }

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        for (int i = 0; i < _blocks.Count; i++)
        {
            if (_currentPositionX > _endPositionX)
            {
                _currentPositionX = _startPositionX;
                _currentPositionY++;
            }

            GameObject block = Instantiate(_blocks[i].Prefab, new Vector3(_currentPositionX, _currentPositionY, 0), Quaternion.identity);
            _currentPositionX++;

            if (block.TryGetComponent(out Block brick))
            {
                _bricks.Add(brick);
                brick.SetData(_blocks[i]);
                brick.Died += OnDied;
            }
        }
    }

    public void RestoreAll()
    {
        BlocksAlife = _blocks.Count;

        foreach (Block block in _bricks)
        {
            block.Restore();
        }
    }

    public void OnDied(int score)
    {
        ScoreReceived?.Invoke(score);
        BlocksAlife--;

        if(BlocksAlife <= 0)
        {
            AllBlocksDied?.Invoke();
        }
    }
}
