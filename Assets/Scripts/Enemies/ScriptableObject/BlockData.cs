using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockData", menuName = "GameData/Create/BlockData")]

public class BlockData : EnemyData
{
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private Color _baseColor;

    public Color BaseColor => _baseColor;

    public int GetSpritesCount()
    {
        return _sprites.Count;
    }

    public Sprite GetSprite(int index)
    {
        return _sprites[index];
    }
}
