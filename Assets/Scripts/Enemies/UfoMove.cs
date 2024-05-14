using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;

public class UfoMove : MonoBehaviour
{
    private float _endPositionX;
    private int _duration;
    private Sequence _sequence;

    private void Awake()
    {
        _duration = 10;
    }

    public void SetPositionX(float positionX)
    {
        _endPositionX = positionX;
    }

    public void Run()
    {
        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOMove(new Vector2(_endPositionX, transform.position.y), _duration));
        _sequence.SetLoops(-1, LoopType.Yoyo);
    }

    public void Stop()
    {
        _sequence.Kill();
    }
}
