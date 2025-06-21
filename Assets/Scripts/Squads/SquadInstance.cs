using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FormationController))]
public class SquadInstance : MonoBehaviour
{
    public SquadLoadout Loadout { get; private set; }
    public FormationController Formation { get; private set; }
    private readonly List<UnitController> units = new();
    private readonly Dictionary<UnitController, TroopData> unitToTroop = new();

    public void Initialize(SquadLoadout loadout)
    {
        Loadout = loadout;
        Formation = GetComponent<FormationController>();

        SpawnUnits();
    }

    private void SpawnUnits()
    {
        if (Loadout == null) return;

        foreach (var troop in Loadout.troops)
        {
            for (int i = 0; i < troop.unitCount; i++)
            {
                GameObject unitObj = Instantiate(troop.unitPrefab, transform.position, Quaternion.identity, transform);
                var controller = unitObj.GetComponent<UnitController>();
                if (controller != null)
                {
                    controller.OnDeath += HandleUnitDeath;
                    units.Add(controller);
                    unitToTroop[controller] = troop;
                    Formation.RegisterUnit(controller);
                }
            }

            SquadStatsTracker.Instance.RegisterSquad(troop, troop.unitCount);
        }
    }

    private void HandleUnitDeath(UnitController unit)
    {
        if (Loadout == null) return;
        if (unitToTroop.TryGetValue(unit, out var troop))
        {
            SquadStatsTracker.Instance.NotifyUnitDeath(troop);
            unitToTroop.Remove(unit);
        }

        unit.OnDeath -= HandleUnitDeath;
        Formation.UnregisterUnit(unit);
        units.Remove(unit);
    }

    public IReadOnlyList<UnitController> GetUnits() => units;
}
