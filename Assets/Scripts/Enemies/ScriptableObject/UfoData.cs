using UnityEngine;

[CreateAssetMenu(fileName = "UfoData", menuName = "GameData/Create/UfoData")]
public class UfoData : EnemyData
{
    [SerializeField] private int _life;
    [SerializeField] private float _startPositionX;
    [SerializeField] private float _endPositionX;
    [SerializeField] private float _positionY;

    public int Life => _life;
    public float StartPositionX => _startPositionX;
    public float EndPositionX => _endPositionX;
    public float PositionY => _positionY;
}
