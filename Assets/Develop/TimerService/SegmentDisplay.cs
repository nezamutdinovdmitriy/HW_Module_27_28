using System.Collections.Generic;
using UnityEngine;

public class SegmentDisplay : TimerDisplay
{
    [SerializeField] private GameObject _timeSegmentPrefab;

    private List<GameObject> _segments;

    public override void Initialize(TimerLogic timer)
    {
        base.Initialize(timer);

        _segments = new List<GameObject>();

        int count = Mathf.CeilToInt(timer.TimeLimit);

        for (int i = 0; i < count; i++)
            _segments.Add(Instantiate(_timeSegmentPrefab, transform));
    }

    protected override void UpdateVisual(float currentTime)
    {
        int activeSegments = Mathf.CeilToInt(currentTime);

        for (int i = 0; i < _segments.Count; i++)
            _segments[i].SetActive(i < activeSegments);
    }
}
