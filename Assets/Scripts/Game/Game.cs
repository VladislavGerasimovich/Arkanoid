using UnityEngine;

[RequireComponent(typeof(BlocksGenerator))]
[RequireComponent(typeof(UfoGenerator))]
public class Game : MonoBehaviour
{
    [SerializeField] private BallMove _ballMove;
    [SerializeField] private EndPanel _endPanel;
    [SerializeField] private LostZone _lostZone;
    [SerializeField] private PlayerMovement _playerMovement;

    private BlocksGenerator _blocksGenerator;
    private UfoGenerator _ufoGenerator;
    private bool _isWin;

    private void Awake()
    {
        _blocksGenerator = GetComponent<BlocksGenerator>();
        _ufoGenerator = GetComponent<UfoGenerator>();
    }

    private void OnEnable()
    {
        _endPanel.RestartButtonClick += Restart;
        _lostZone.BallOutOfZone += OnBallOutOfZone;
        _blocksGenerator.AllBlocksDied += OnEnemiesDied;
        _ufoGenerator.AllUfoDied += OnEnemiesDied;
    }

    private void OnDisable()
    {
        _endPanel.RestartButtonClick -= Restart;
        _lostZone.BallOutOfZone -= OnBallOutOfZone;
        _blocksGenerator.AllBlocksDied -= OnEnemiesDied;
        _ufoGenerator.AllUfoDied -= OnEnemiesDied;
    }

    private void OnEnemiesDied()
    {
        if (_blocksGenerator.BlocksAlife <= 0 && _ufoGenerator.UfoAlife <= 0)
        {
            _isWin = true;
            _endPanel.Show(_isWin);
        }
    }

    private void OnBallOutOfZone()
    {
        _isWin = false;
        _endPanel.Show(_isWin);
    }

    private void Restart()
    {
        _blocksGenerator.RestoreAll();
        _ufoGenerator.RestoreAll();
        _ballMove.BallDeactivate();
        _playerMovement.SetStartPosition();
    }
}
