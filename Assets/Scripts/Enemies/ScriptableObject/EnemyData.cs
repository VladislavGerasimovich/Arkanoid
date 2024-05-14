using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyData : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _score;

    public GameObject Prefab => _prefab;
    public int Score => _score;
}
