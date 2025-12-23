using UnityEngine;
using UnityEngine.UI;

public class SlideTimerView : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _fill;

    public Image Fill => _fill;
}
