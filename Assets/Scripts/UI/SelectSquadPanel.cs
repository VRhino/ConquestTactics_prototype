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

    public System.Action<SquadLoadout> OnSquadSelected;
    public SquadLoadout SelectedLoadout { get; private set; }

    /// <summary>
    /// Populates the UI with all available loadouts.
    /// </summary>
    /// <param name="available">List of possible squad loadouts.</param>
    /// <param name="alreadyUsed">Optional set with loadouts that can't be selected.</param>
    public void Populate(List<SquadLoadout> available, HashSet<SquadLoadout> alreadyUsed = null)
    {
        Clear();
        loadouts = available;
        foreach (var loadout in loadouts)
        {
            Button btn = Instantiate(entryPrefab, listContainer);
            created.Add(btn);
            var txt = btn.GetComponentInChildren<Text>();
            if (txt != null)
                txt.text = loadout.name;

            bool used = alreadyUsed != null && alreadyUsed.Contains(loadout);
            btn.interactable = !used;

            if (!used && HasLowTroops(loadout))
            {
                if (txt != null)
                    txt.color = Color.yellow;
            }

            var l = loadout;
            btn.onClick.AddListener(() => Select(l));
        }
    }

    private bool HasLowTroops(SquadLoadout loadout)
    {
        if (loadout == null)
            return false;
        foreach (var troop in loadout.troops)
        {
            if (SquadStatsTracker.Instance.GetRemainingTroopPercentage(troop) <= 0.1f)
                return true;
        }
        return false;
    }

    private void Select(SquadLoadout loadout)
    {
        SelectedLoadout = loadout;
        OnSquadSelected?.Invoke(loadout);
    }

    private void Clear()
    {
        foreach (var b in created)
            Destroy(b.gameObject);
        created.Clear();
        SelectedLoadout = null;
    }
}
