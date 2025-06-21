using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Central manager in charge of handling the player's active squad.
/// Only one squad can be active at the same time.
/// </summary>
public class SquadManager : MonoBehaviour
{
    public static SquadManager Instance { get; private set; }

    [Tooltip("Currently active squad instance in the scene")]
    public SquadInstance activeSquad;

    [Tooltip("Spawn point used when spawning a new squad")]
    public Transform defaultSpawnPoint;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    /// <summary>
    /// Spawns a new squad based on the given loadout at the specified position.
    /// If another squad is active, spawning fails.
    /// </summary>
    public SquadInstance SpawnSquadFromLoadoutAt(SquadLoadout loadout, Vector3 position)
    {
        if (loadout == null)
        {
            Debug.LogWarning("SpawnSquadFromLoadoutAt called with null loadout");
            return null;
        }

        if (activeSquad != null)
        {
            Debug.LogWarning("Trying to spawn a new squad while another is active.");
            return null;
        }

        GameObject go = new GameObject("SquadInstance");
        go.transform.position = position;
        var instance = go.AddComponent<SquadInstance>();
        instance.Initialize(loadout);

        activeSquad = instance;
        return instance;
    }

    /// <summary>
    /// Destroys the current squad after a delay. Immediately clears the active reference.
    /// </summary>
    public void DeactivateCurrentSquad(float delay)
    {
        if (activeSquad == null) return;
        StartCoroutine(DeactivateCoroutine(activeSquad, delay));
        activeSquad = null;
    }

    private IEnumerator DeactivateCoroutine(SquadInstance squad, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (squad != null)
            Destroy(squad.gameObject);
    }

    public IReadOnlyList<UnitController> GetActiveUnits()
    {
        return activeSquad != null ? activeSquad.GetUnits() : new List<UnitController>();
    }

    /// <summary>
    /// Returns true when there are no units alive in the current squad.
    /// </summary>
    public bool HasNoUnits()
    {
        return GetActiveUnits().Count == 0;
    }

    /// <summary>
    /// Total number of units defined in the active loadout.
    /// </summary>
    public int GetInitialUnitCount()
    {
        if (activeSquad == null || activeSquad.Loadout == null)
            return 0;

        int count = 0;
        foreach (var troop in activeSquad.Loadout.troops)
        {
            if (troop != null)
                count += troop.unitCount;
        }
        return count;
    }

    /// <summary>
    /// Current count of alive units in the active squad.
    /// </summary>
    public int GetCurrentUnitCount()
    {
        return GetActiveUnits().Count;
    }
}

