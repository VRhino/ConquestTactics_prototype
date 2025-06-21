using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Controls the tactical formation of a squad. Units follow the leader's position
/// based on the current FormationData.
/// </summary>
public class FormationController : MonoBehaviour
{
    [Header("Formation Settings")]
    [Tooltip("Current formation profile used by the squad")]
    public FormationData currentFormation;

    [Tooltip("Transform of the unit considered as the leader")]
    public Transform leaderTransform;

    // Active members of the squad
    private readonly List<UnitController> units = new();

    private void Update()
    {
        UpdateFormationPositions();
    }

    /// <summary>
    /// Registers a unit into the formation.
    /// </summary>
    public void RegisterUnit(UnitController unit)
    {
        if (unit == null || units.Contains(unit))
            return;

        units.Add(unit);
        unit.OnDeath += OnUnitDeath;
        ReassignPositions();
    }

    /// <summary>
    /// Removes a unit from the formation (called when a unit dies or leaves).
    /// </summary>
    public void UnregisterUnit(UnitController unit)
    {
        if (unit == null)
            return;

        if (units.Remove(unit))
        {
            unit.OnDeath -= OnUnitDeath;
            ReassignPositions();
        }
    }

    /// <summary>
    /// Applies a new formation and redistributes unit positions.
    /// </summary>
    public void ApplyFormation(FormationData newFormation)
    {
        currentFormation = newFormation;
        ReassignPositions();
    }

    /// <summary>
    /// Updates the destination of each unit every frame so they keep formation while the leader moves.
    /// Units without an available slot are put on standby.
    /// </summary>
    private void UpdateFormationPositions()
    {
        if (leaderTransform == null || currentFormation == null)
            return;

        for (int i = 0; i < units.Count; i++)
        {
            UnitController unit = units[i];
            if (unit == null || !unit.isAlive)
                continue;

            if (i < currentFormation.relativePositions.Count)
            {
                Vector3 offset = currentFormation.relativePositions[i];
                Vector3 worldPos = leaderTransform.position + leaderTransform.rotation * offset;

                unit.assignedFormationPosition = worldPos;
                unit.SetFormationMode(true);

                if (unit.agent != null)
                {
                    unit.agent.SetDestination(worldPos);
                }
            }
            else
            {
                // Extra units wait without a slot
                unit.SetFormationMode(false);
            }
        }
    }

    /// <summary>
    /// Reassigns slots when the formation changes or units are added/removed.
    /// </summary>
    public void ReassignPositions()
    {
        UpdateFormationPositions();
    }

    /// <summary>
    /// Callback when a unit dies to keep formation cohesion.
    /// </summary>
    public void OnUnitDeath(UnitController unit)
    {
        UnregisterUnit(unit);
    }
}
