using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlocksGenerator))]
[RequireComponent(typeof(UfoGenerator))]
public class ScoreSystemSetup : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private EndPanel _endPanel;

    private ScoreSystemPresenter _scoreSystemPresenter;
    private BlocksGenerator _blocksGenerator;
    private UfoGenerator _ufoGenerator;

    private void Awake()
    {
        _blocksGenerator = GetComponent<BlocksGenerator>();
        _ufoGenerator = GetComponent<UfoGenerator>();
        ScoreSystem scoreSystem = new ScoreSystem();
        _scoreSystemPresenter = new ScoreSystemPresenter(scoreSystem, _blocksGenerator, _ufoGenerator, _score, _endPanel);
    }

    private void OnEnable()
    {
        _scoreSystemPresenter.Enable();
    }

    private void OnDisable()
    {
        _scoreSystemPresenter.Disable();
    }
}
