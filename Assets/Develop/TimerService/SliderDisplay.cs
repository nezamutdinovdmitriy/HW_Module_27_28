using UnityEngine;

public class SliderDisplay : TimerDisplay
{
    [SerializeField] private SlideTimerView _sliderPrefab;

    protected override void UpdateVisual(float currentTime)
    {
        _sliderPrefab.Fill.fillAmount = currentTime / Timer.TimeLimit;
    }
}
