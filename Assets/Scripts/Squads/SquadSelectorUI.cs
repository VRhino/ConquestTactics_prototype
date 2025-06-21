using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Simple UI component for displaying available squads.
/// Squads with less than 10% troops alive are shown as disabled.
/// </summary>
public class SquadSelectorUI : MonoBehaviour
{
    public Button entryPrefab;
    public Transform container;

    private readonly List<Button> createdButtons = new();
    private SquadManager manager;
    private List<TroopData> troops;

    public void Populate(List<TroopData> availableTroops, SquadManager mgr)
    {
        Clear();
        manager = mgr;
        troops = availableTroops;
        foreach (var troop in troops)
        {
            Button btn = Instantiate(entryPrefab, container);
            btn.GetComponentInChildren<Text>().text = troop.name;
            createdButtons.Add(btn);

            bool viable = SquadStatsTracker.Instance.GetRemainingTroopPercentage(troop) > 0.1f;
            bool isActiveTroop = manager.activeSquad != null && manager.activeSquad.Loadout.troops.Contains(troop);
            btn.interactable = viable && !isActiveTroop;

            if (viable)
            {
                btn.onClick.AddListener(() => OnClickSquad(troop));
            }
        }
    }

    private void OnClickSquad(TroopData troop)
    {
        var loadout = ScriptableObject.CreateInstance<SquadLoadout>();
        loadout.troops.Add(troop);
        manager.DeactivateCurrentSquad(0f);
        manager.SpawnSquadFromLoadoutAt(loadout, manager.defaultSpawnPoint.position);
    }

    private void Clear()
    {
        foreach (var b in createdButtons)
            Destroy(b.gameObject);
        createdButtons.Clear();
    }
}

