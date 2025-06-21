using UnityEngine;

/// <summary>
/// Basic perk information used for display purposes.
/// </summary>
[CreateAssetMenu(fileName = "NewPerkData", menuName = "Characters/Perk")]
public class PerkData : ScriptableObject
{
    public Sprite icon;
    public string perkName;
    [TextArea] public string description;
}
