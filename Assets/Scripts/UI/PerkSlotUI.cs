using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI element displaying a single perk's icon and text.
/// </summary>
public class PerkSlotUI : MonoBehaviour
{
    public Image icon;
    public Text nameText;
    public Text descriptionText;

    /// <summary>
    /// Fills the slot with the perk data.
    /// </summary>
    public void Setup(PerkData data)
    {
        if (data == null)
            return;
        if (icon != null) icon.sprite = data.icon;
        if (nameText != null) nameText.text = data.perkName;
        if (descriptionText != null) descriptionText.text = data.description;
    }
}
