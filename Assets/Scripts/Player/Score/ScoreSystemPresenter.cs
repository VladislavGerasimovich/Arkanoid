public class ScoreSystemPresenter
{
    private ScoreSystem _scoreSystem;
    private BlocksGenerator _blocksGenerator;
    private UfoGenerator _ufoGenerator;
    private Score _score;
    private EndPanel _endPanel;

    public ScoreSystemPresenter(ScoreSystem scoreSystem, BlocksGenerator blocksGenerator, UfoGenerator ufoGenerator, Score score, EndPanel endPanel)
    {
        _scoreSystem = scoreSystem;
        _blocksGenerator = blocksGenerator;
        _ufoGenerator = ufoGenerator;
        _score = score;
        _endPanel = endPanel;
    }

    public void Enable()
    {
        _endPanel.RestartButtonClick += OnRestartButtonClick;
        _scoreSystem.ValueChanged += OnValueChanged;
        _blocksGenerator.ScoreReceived += OnScoreReceived;
        _ufoGenerator.ScoreReceived += OnScoreReceived;
    }

    public void Disable()
    {
        _endPanel.RestartButtonClick -= OnRestartButtonClick;
        _scoreSystem.ValueChanged -= OnValueChanged;
        _blocksGenerator.ScoreReceived -= OnScoreReceived;
        _ufoGenerator.ScoreReceived -= OnScoreReceived;
    }

    private void OnScoreReceived(int score)
    {
        _scoreSystem.Add(score);
    }

    private void OnValueChanged()
    {
        _scoreSystem.GetValue(out int score);
        _score.SetText(score);
    }

    private void OnRestartButtonClick()
    {
        _scoreSystem.ResetValue();
    }
}
