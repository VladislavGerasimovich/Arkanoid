using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class EndPanel : MonoBehaviour
{
    [SerializeField] private string _winningText;
    [SerializeField] private string _loserText;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _restartButton;

    private CanvasGroup _canvasGroup;

    public event Action RestartButtonClick;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show(bool isWin)
    {
        Time.timeScale = 0;
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;

        if (isWin == true)
        {
            _text.text = _winningText;
            return;
        }
        else
        {
            _text.text = _loserText;
        }
    }

    private void Hide()
    {
        Time.timeScale = 1;
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }

    private void OnRestartButtonClick()
    {
        RestartButtonClick?.Invoke();
        Hide();
    }
}
