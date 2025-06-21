using UnityEngine;

/// <summary>
/// Handles final actions once the battle is over.
/// This is a placeholder implementation that can be expanded later.
/// </summary>
public static class EndBattleHandler
{
    public static void HandleBattleEnd(BattleManager.BattleState result)
    {
        Debug.Log($"EndBattleHandler received result: {result}");
        // Additional behaviour such as scene transitions would go here.
    }
}
