using UnityEngine;

/// <summary>
/// Data container with final statistics of a battle.
/// </summary>
public class BattleResultData
{
    public BattleManager.BattleState result;
    public float totalTime;
    public string squadName;
    public int initialTroops;
    public int survivingTroops;
}
