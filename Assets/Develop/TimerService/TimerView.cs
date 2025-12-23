using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private Button _resumeButton;

    [SerializeField] private Image _backgroundImage;

    [SerializeField] private Transform _displayContainer;

    public void Initialize(TimerLogic timerLogic, TimerDisplay displayPrefab)
    {
        TimerDisplay display = Instantiate(displayPrefab, _displayContainer);
        display.Initialize(timerLogic);

        _startButton.onClick.AddListener(timerLogic.Start);
        _stopButton.onClick.AddListener(timerLogic.Stop);
        _resumeButton.onClick.AddListener(timerLogic.Resume);
        _resetButton.onClick.AddListener(timerLogic.Reset);
    }
}
