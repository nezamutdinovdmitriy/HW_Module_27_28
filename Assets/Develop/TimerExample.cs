using UnityEngine;

public class TimerExample : MonoBehaviour
{
    [SerializeField] private float _timeLimit;
    [SerializeField] private TimerViewType _viewType;

    [SerializeField] private TimerView _timerViewPrefab;
    [SerializeField] private SliderDisplay _sliderPrefab;
    [SerializeField] private SegmentDisplay _segmentPrefab;
    [SerializeField] private Canvas _canvas;

    private TimerLogic _timerLogic;

    private void Awake()
    {
        _timerLogic = new TimerLogic(_timeLimit, this);

        TimerView view = Instantiate(_timerViewPrefab, _canvas.transform);

        TimerDisplay selectedDisplay;

        switch (_viewType)
        {
            case TimerViewType.Slider:
                selectedDisplay = _sliderPrefab;
                break;

            case TimerViewType.Segment:
                selectedDisplay = _segmentPrefab;
                break;

            default:
                selectedDisplay = null;
                break;
        }

        if (selectedDisplay != null)
            view.Initialize(_timerLogic, selectedDisplay);
    }
}
