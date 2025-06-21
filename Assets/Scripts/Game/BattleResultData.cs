using UnityEngine;

/// <summary>
/// Data container with final statistics of a battle.
/// </summary>
public class BattleResultData
{
    /// <summary>
    /// Final state of the battle.
    /// </summary>
    public BattleManager.BattleState result;

    /// <summary>
    /// Name of the squad used by the player.
    /// </summary>
    public string squadName;

    /// <summary>
    /// Units remaining at the end of the battle.
    /// </summary>
    public int unitsRemaining;

    /// <summary>
    /// Units the player started the battle with.
    /// </summary>
    public int unitsInitial;

    /// <summary>
    /// Total duration of the battle in seconds.
    /// </summary>
    public float battleDuration;

    /// <summary>
    /// Optional number of defeated enemies.
    /// </summary>
    public int enemiesDefeated;
}
