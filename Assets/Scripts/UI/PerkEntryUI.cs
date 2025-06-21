using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Helper component to display a single perk in the UI.
/// </summary>
public class PerkEntryUI : MonoBehaviour
{
    public Image icon;
    public Text nameText;
    public Text descriptionText;

    public void Setup(PerkData data)
    {
        if (data == null)
            return;
        if (icon != null) icon.sprite = data.icon;
        if (nameText != null) nameText.text = data.perkName;
        if (descriptionText != null) descriptionText.text = data.description;
    }
}
