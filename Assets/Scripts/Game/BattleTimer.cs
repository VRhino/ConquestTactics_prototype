using UnityEngine;

/// <summary>
/// Component that tracks battle duration and notifies interested systems.
/// </summary>
public class BattleTimer : MonoBehaviour
{
    /// <summary>
    /// Global access to the active timer instance.
    /// </summary>
    public static BattleTimer Instance { get; private set; }

    [Header("Time Limit")]
    public bool useTimeLimit = false;
    public float timeLimit = 300f;

    /// <summary>
    /// Invoked every frame while the timer is running with the current time.
    /// </summary>
    public event System.Action<float> OnTimerTick;

    /// <summary>
    /// Invoked once when remaining time drops below 30 seconds.
    /// </summary>
    public event System.Action<float> OnTimeWarning;

    private float elapsedTime;
    private bool running;
    private bool warningSent;

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
        if (!running)
            return;

        elapsedTime += Time.deltaTime;
        OnTimerTick?.Invoke(elapsedTime);

        if (useTimeLimit)
        {
            float remaining = timeLimit - elapsedTime;
            if (!warningSent && remaining <= 30f)
            {
                warningSent = true;
                OnTimeWarning?.Invoke(remaining);
            }

            if (elapsedTime >= timeLimit)
            {
                running = false;
                Debug.Log("BattleTimer reached time limit");
                if (BattleManager.Instance != null)
                    BattleManager.Instance.ForceDefeat("Tiempo agotado");
            }
        }
    }

    /// <summary>
    /// Starts counting time from zero.
    /// </summary>
    public void StartTimer()
    {
        elapsedTime = 0f;
        running = true;
        warningSent = false;
    }

    /// <summary>
    /// Stops the timer.
    /// </summary>
    public void StopTimer()
    {
        running = false;
    }

    /// <summary>
    /// Returns the current elapsed time in seconds.
    /// </summary>
    public static float GetElapsedTime()
    {
        return Instance != null ? Instance.elapsedTime : 0f;
    }

    /// <summary>
    /// Returns the elapsed time formatted as mm:ss.
    /// </summary>
    public string GetFormattedTime()
    {
        int mins = Mathf.FloorToInt(elapsedTime / 60f);
        int secs = Mathf.FloorToInt(elapsedTime % 60f);
        return $"{mins:00}:{secs:00}";
    }

    /// <summary>
    /// Returns the formatted elapsed time from the active instance.
    /// </summary>
    public static string GetFormattedElapsedTime()
    {
        return Instance != null ? Instance.GetFormattedTime() : "00:00";
    }

    [ContextMenu("Start Timer")]
    private void ContextStart()
    {
        StartTimer();
    }

    [ContextMenu("Stop Timer")]
    private void ContextStop()
    {
        StopTimer();
    }
}
