using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Read-only list showing the hero's passive perks.
/// </summary>
public class PerkPreviewPanel : MonoBehaviour
{
    public PerkSlotUI perkSlotPrefab;
    public Transform container;
    public GameObject noPerksMessage;
    [Header("Testing")]
    public List<PerkData> mockPerks = new();

    private readonly List<GameObject> created = new();

    /// <summary>
    /// Populates the panel with the given perks.
    /// </summary>
    public void ShowPerks(List<PerkData> perks)
    {
        Clear();
        bool hasPerks = perks != null && perks.Count > 0;
        if (noPerksMessage != null)
            noPerksMessage.SetActive(!hasPerks);
        if (!hasPerks)
            return;

        foreach (var perk in perks)
        {
            var slot = Instantiate(perkSlotPrefab, container);
            slot.Setup(perk);
            created.Add(slot.gameObject);
        }
    }

    /// <summary>
    /// Loads mock perks assigned from the inspector for testing.
    /// </summary>
    public void LoadMockPerks()
    {
        ShowPerks(mockPerks);
    }

    private void Clear()
    {
        foreach (var go in created)
            Destroy(go);
        created.Clear();
    }
}
