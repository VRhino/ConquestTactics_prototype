using UnityEngine;

/// <summary>
/// Simple placeholder for displaying battle results.
/// </summary>
public class BattleResultsUI : MonoBehaviour
{
    public void Show(BattleResultData data)
    {
        Debug.Log($"Showing results: {data.result} - Time {data.totalTime}");
    }
}
