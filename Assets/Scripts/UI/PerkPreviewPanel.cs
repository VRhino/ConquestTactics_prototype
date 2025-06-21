using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Read-only list showing the hero's passive perks.
/// </summary>
public class PerkPreviewPanel : MonoBehaviour
{
    public PerkEntryUI entryPrefab;
    public Transform container;

    private readonly List<GameObject> created = new();

    /// <summary>
    /// Populates the panel with the given perks.
    /// </summary>
    public void Populate(List<PerkData> perks)
    {
        Clear();
        if (perks == null) return;
        foreach (var perk in perks)
        {
            var entry = Instantiate(entryPrefab, container);
            entry.Setup(perk);
            created.Add(entry.gameObject);
        }
    }

    private void Clear()
    {
        foreach (var go in created)
            Destroy(go);
        created.Clear();
    }
}
