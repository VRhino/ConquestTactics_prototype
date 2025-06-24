using System;
using UnityEngine;

/// <summary>
/// Component responsible for tracking the elapsed battle time
/// and optionally enforcing a maximum duration.
/// </summary>
public class BattleTimer : MonoBehaviour
{
    /// <summary>
    /// Global access to the active BattleTimer instance.
    /// </summary>
    public static BattleTimer Instance { get; private set; }

    [Header("Settings")]
    [Tooltip("If true, a defeat is triggered once the limit is reached.")]
    public bool useTimeLimit = false;
    [Tooltip("Maximum allowed battle duration in seconds.")]
    public float timeLimit = 300f;

    /// <summary>
    /// Event fired every second with the current elapsed time.
    /// </summary>
    public event Action<float> OnTimerTick;

    /// <summary>
    /// Event fired when only 30 seconds remain and the time limit is active.
    /// </summary>
    public event Action<float> OnTimeWarning;

    private float elapsedTime;
    private bool isRunning;
    private bool warningIssued;
    private float tickAccumulator;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (!isRunning)
            return;

        elapsedTime += Time.deltaTime;
        tickAccumulator += Time.deltaTime;

        if (tickAccumulator >= 1f)
        {
            tickAccumulator = 0f;
            OnTimerTick?.Invoke(elapsedTime);
        }

        if (useTimeLimit)
        {
            float remaining = timeLimit - elapsedTime;

            if (!warningIssued && remaining <= 30f && remaining > 0f)
            {
                warningIssued = true;
                OnTimeWarning?.Invoke(remaining);
            }

            if (remaining <= 0f)
            {
                isRunning = false;
#if UNITY_EDITOR
                Debug.Log("BattleTimer: time limit reached");
#endif
                if (BattleManager.Instance != null)
                    BattleManager.Instance.ForceDefeat("Tiempo agotado");

                OnTimerTick?.Invoke(timeLimit);
            }
        }
    }

    /// <summary>
    /// Starts or resets the timer.
    /// </summary>
    [ContextMenu("Start Timer")]
    public void StartTimer()
    {
        elapsedTime = 0f;
        tickAccumulator = 0f;
        warningIssued = false;
        isRunning = true;
        OnTimerTick?.Invoke(0f);
    }

    /// <summary>
    /// Stops the timer without resetting the value.
    /// </summary>
    [ContextMenu("Stop Timer")]
    public void StopTimer()
    {
        isRunning = false;
    }

    /// <summary>
    /// Current elapsed time in seconds.
    /// </summary>
    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    /// <summary>
    /// Elapsed time in MM:SS format.
    /// </summary>
    public string GetFormattedTime()
    {
        int mins = Mathf.FloorToInt(elapsedTime / 60f);
        int secs = Mathf.FloorToInt(elapsedTime % 60f);
        return $"{mins:00}:{secs:00}";
    }
}
