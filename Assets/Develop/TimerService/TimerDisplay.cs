using UnityEngine;

public abstract class TimerDisplay : MonoBehaviour
{
    protected TimerLogic Timer;

    public virtual void Initialize(TimerLogic timer)
    {
        Timer = timer;

        Timer.TimeChanged += UpdateVisual;
    }

    private void OnDestroy()
    {
        if (Timer != null)
            Timer.TimeChanged -= UpdateVisual;
    }

    protected abstract void UpdateVisual(float currentTime);    
}
