using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays available squad loadouts for the player to choose from.
/// </summary>
public class SelectSquadPanel : MonoBehaviour
{
    public Button entryPrefab;
    public Transform listContainer;

    private readonly List<Button> created = new();
    private List<SquadLoadout> loadouts;

    public System.Action<SquadLoadout> OnLoadoutSelected;
    public SquadLoadout SelectedLoadout { get; private set; }

    /// <summary>
    /// Populates the UI with all available loadouts.
    /// </summary>
    public void Populate(List<SquadLoadout> available)
    {
        Clear();
        loadouts = available;
        foreach (var loadout in loadouts)
        {
            Button btn = Instantiate(entryPrefab, listContainer);
            created.Add(btn);
            btn.GetComponentInChildren<Text>().text = loadout.name;

            btn.interactable = IsLoadoutViable(loadout);
            var l = loadout;
            btn.onClick.AddListener(() => Select(l));
        }
    }

    private bool IsLoadoutViable(SquadLoadout loadout)
    {
        if (loadout == null)
            return false;
        foreach (var troop in loadout.troops)
        {
            if (SquadStatsTracker.Instance.GetRemainingTroopPercentage(troop) <= 0.1f)
                return false;
        }
        return true;
    }

    private void Select(SquadLoadout loadout)
    {
        SelectedLoadout = loadout;
        OnLoadoutSelected?.Invoke(loadout);
    }

    private void Clear()
    {
        foreach (var b in created)
            Destroy(b.gameObject);
        created.Clear();
        SelectedLoadout = null;
    }
}
