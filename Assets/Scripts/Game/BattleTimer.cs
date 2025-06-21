using UnityEngine;

/// <summary>
/// Simple utility to track how much time has passed since the battle started.
/// </summary>
public static class BattleTimer
{
    private static float startTime;
    private static bool started;

    /// <summary>
    /// Starts or resets the timer.
    /// </summary>
    public static void StartTimer()
    {
        startTime = Time.time;
        started = true;
    }

    /// <summary>
    /// Returns the elapsed time in seconds since the timer started.
    /// </summary>
    public static float GetElapsedTime()
    {
        return started ? Time.time - startTime : 0f;
    }
}
