using TMPro;
using UnityEngine;

public class DayPeriodControllerView : MonoBehaviour
{
    private const string format = "{0} / {1}";

    [SerializeField] private TMP_Text _viewText;

    private DayPeriodController _controller;
    private int _totalValue;

    public void Setup(int current, int total, DayPeriodController currentEvent)
    {
        _totalValue = total;
        SetVisualPeriod(current, _totalValue);
        _controller = currentEvent;
        SetPeriodEvent(currentEvent);
    }

    private void SetVisualPeriod(int current, int total)
    {
        _viewText.text = string.Format(format, current, total);
    }

    private void SetPeriodEvent(DayPeriodController controller)
    {
        _controller.OnTick -= onTickHandler;

        _controller = controller;
        controller.OnTick += onTickHandler;

        void onTickHandler(int currentValue)
        {
            SetVisualPeriod(currentValue, _totalValue);
        }
    }
}
