using UnityEngine;

/// <summary>
/// Simplified game manager with helper methods used from UI.
/// </summary>
public static class GameManager
{
    /// <summary>
    /// Spawns a squad using the global SquadManager instance.
    /// </summary>
    public static void SpawnSquad(SquadLoadout loadout)
    {
        if (loadout == null)
        {
            Debug.LogWarning("SpawnSquad called with null loadout");
            return;
        }

        var manager = SquadManager.Instance;
        if (manager != null)
        {
            manager.SpawnSquadFromLoadoutAt(loadout, manager.defaultSpawnPoint.position);
        }
        else
        {
            Debug.LogWarning("No SquadManager instance found");
        }
    }
}
