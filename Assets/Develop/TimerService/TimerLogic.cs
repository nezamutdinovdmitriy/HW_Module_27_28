using System;
using System.Collections;
using UnityEngine;

public class TimerLogic
{
    public event Action<float> TimeChanged;
    public event Action Finished;

    private float _timeLimit;
    private float _currentTime;
    private bool _isRunning;

    private Coroutine _activeTimer;
    private MonoBehaviour _coroutineRunner;

    public TimerLogic(float timeLimit, MonoBehaviour coroutineRunner)
    {
        _timeLimit = timeLimit;
        _currentTime = _timeLimit;

        _coroutineRunner = coroutineRunner;
    }

    public float TimeLimit => _timeLimit;
    public float CurrentTime => _currentTime;

    public void Start()
    {
        if (_isRunning)
            return;

        _isRunning = true;

        _activeTimer = _coroutineRunner.StartCoroutine(TimerProcess());
    }

    public void Stop()
    {
        if (_isRunning == false)
            return;

        _isRunning = false;

        if (_activeTimer != null)
            _coroutineRunner.StopCoroutine(_activeTimer);
    }

    public void Resume() => Start();

    public void Reset()
    {
        Stop();

        _currentTime = _timeLimit;

        TimeChanged?.Invoke(_currentTime);
    }

    private IEnumerator TimerProcess()
    {
        while (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            
            TimeChanged?.Invoke(_currentTime);
            
            Debug.Log(_currentTime);

            yield return null;
        }

        _currentTime = 0;
        
        TimeChanged?.Invoke(_currentTime);

        _isRunning = false;

        Finished?.Invoke();

        Debug.Log("Звоночек!");
    }
}
