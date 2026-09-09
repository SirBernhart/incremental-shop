using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DayPeriodController : MonoBehaviour
{
    public event Action<int> OnTick;
    public event Action OnPeriodEnd;

    [SerializeField] private DayPeriodControllerView view;

    [Header("FUTURE STANDALONE CONFIG")]
    [SerializeField] private int tickSize = 1;
    [SerializeField] private int timerGoal = 60;

    public int GetTimerGoal => timerGoal;

    private int currentTime;
    private int goalTime;

    private void Awake()
    {
        view.Setup(0, timerGoal, this);
        StartTimer(tickSize, timerGoal);
    }

    public void StartTimer(int tickSeconds, int goalSeconds)
    {
        if(tickSize <= 0 || timerGoal <= 0)
        {
            UnityEngine.Debug.LogError($"DayPeriodController.StartTimer - Neither tickSize ({tickSize}) or timerGoal ({timerGoal}) lesser than 1");
            return;
        }

        StartTickingAsync(tickSeconds, goalSeconds).Forget();
    }

    public async UniTask StartTickingAsync(int tickSeconds, int goalSeconds)
    {
        int tickMilliseconds = tickSeconds * 1000;
        int goalMilliseconds = goalSeconds * 1000;
        goalTime = goalMilliseconds;

        currentTime = 0;

        while(IsPeriodEnded())
        {
            await UniTask.Delay(tickMilliseconds);
            currentTime += tickMilliseconds;
            OnTick?.Invoke((int)(currentTime * 0.001f));
        }

        OnPeriodEnd?.Invoke();
    }

    public bool IsPeriodEnded()
    {
        return currentTime < goalTime;
    }
}
