using UnityEngine;

/// <summary>
/// Example supply point that allows replacing the active squad.
/// </summary>
public class SupplyPointController : MonoBehaviour
{
    [Tooltip("Delay before the previous squad is fully destroyed")]
    public float despawnDelay = 1f;

    public void ReplaceSquad(SquadLoadout loadout)
    {
        if (loadout == null)
            return;

        var manager = SquadManager.Instance;
        if (manager == null)
            return;

        manager.DeactivateCurrentSquad(despawnDelay);
        manager.SpawnSquadFromLoadoutAt(loadout, manager.defaultSpawnPoint.position);
    }
}

