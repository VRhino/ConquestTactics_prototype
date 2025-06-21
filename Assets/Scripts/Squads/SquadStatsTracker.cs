using System.Collections.Generic;
using UnityEngine;

public class SquadStatsTracker : MonoBehaviour
{
    public static SquadStatsTracker Instance { get; private set; }

    private class SquadInfo
    {
        public int total;
        public int alive;
    }

    private readonly Dictionary<TroopData, SquadInfo> stats = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RegisterSquad(TroopData troop, int unitCount)
    {
        if (troop == null)
            return;

        if (!stats.TryGetValue(troop, out var info))
        {
            info = new SquadInfo();
            stats[troop] = info;
        }

        info.total += unitCount;
        info.alive += unitCount;
    }

    public void NotifyUnitDeath(TroopData troop)
    {
        if (troop == null)
            return;

        if (stats.TryGetValue(troop, out var info))
        {
            info.alive = Mathf.Max(0, info.alive - 1);
        }
    }

    public int GetAliveCount(TroopData troop)
    {
        return stats.TryGetValue(troop, out var info) ? info.alive : 0;
    }

    public int GetTotalCount(TroopData troop)
    {
        return stats.TryGetValue(troop, out var info) ? info.total : 0;
    }

    public float GetRemainingTroopPercentage(TroopData troop)
    {
        if (!stats.TryGetValue(troop, out var info) || info.total == 0)
            return 0f;

        return (float)info.alive / info.total;
    }
}
