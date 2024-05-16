using System;
using System.Collections.Generic;
using UnityEngine;

public class UfoGenerator : MonoBehaviour, IGenerator
{
    [SerializeField] private List<UfoData> _ufoesData;

    private List<Ufo> _ufoes;

    public event Action<int> ScoreReceived;
    public event Action AllUfoDied;

    public int UfoAlife { get; private set; }

    private void Awake()
    {
        UfoAlife = _ufoesData.Count;
        _ufoes = new List<Ufo>();
    }

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        for (int i = 0; i < _ufoesData.Count; i++)
        {
            GameObject ufo = Instantiate(_ufoesData[i].Prefab, new Vector2(_ufoesData[i].StartPositionX, _ufoesData[i].PositionY), Quaternion.identity);

            if (ufo.TryGetComponent(out Ufo plane))
            {
                _ufoes.Add(plane);
                plane.SetData(_ufoesData[i]);
                plane.Died += OnDied;
            }
        }
    }

    public void RestoreAll()
    {
        UfoAlife = _ufoesData.Count;

        foreach (Ufo ufo in _ufoes)
        {
            ufo.Restore();
        }
    }

    public void OnDied(int score)
    {
        ScoreReceived?.Invoke(score);
        UfoAlife--;

        if (UfoAlife <= 0)
        {
            AllUfoDied?.Invoke();
        }
    }
}
